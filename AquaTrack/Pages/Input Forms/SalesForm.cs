using AquaTrack.Data;
using AquaTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaTrack.Pages.Input_Forms
{
    public partial class SalesForm : Form
    {
        private BindingList<SaleLine> _saleLines = new BindingList<SaleLine>();
        private InventoryContext _context;

        public struct SaleLine
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Subtotal { get; set; }
        }
        public SalesForm()
        {
            InitializeComponent();
            siticoneDataGridViewSaleItem.GridView.AutoGenerateColumns = true;
            siticoneDataGridViewSaleItem.DataSource = _saleLines;
        }

        private void siticoneButtonSaleCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneDropdownSaleCustomerName_Click(object sender, EventArgs e)
        {
            using (var customerContext = new Data.InventoryContext(
                new DbContextOptionsBuilder<Data.InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options))
            {
                var customers = customerContext.Customers
                    .Select(c => new { c.CustomerID, c.Name })
                    .ToList();

                siticoneDropdownSaleCustomerName.DataSource = customers;
                siticoneDropdownSaleCustomerName.DisplayMember = "Name";
                siticoneDropdownSaleCustomerName.ValueMember = "CustomerID";
            }
        }

        private void siticoneBtnAddSaleItem_Click(object sender, EventArgs e)
        {
            SaleItemsForm saleItemsForm = new SaleItemsForm();

            if (saleItemsForm.ShowDialog() == DialogResult.OK)
            {
                var createdLine = saleItemsForm.CreatedLine;
                if (createdLine != null)
                {
                    _saleLines.Add(createdLine.Value);
                }
            }
        }

        private void siticoneButtonSaleConfirm_Click(object sender, EventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            // Validate Customer Selection
            if (siticoneDropdownSaleCustomerName.SelectedItem == null || string.IsNullOrWhiteSpace(siticoneDropdownSaleCustomerName.Text))
            {
                MessageBox.Show("Please select a Customer.", "Validation Error");
                return;
            }

            // Validate Sale Items
            if (_saleLines.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the sale.", "Validation Error");
                return;
            }

            if (!int.TryParse(siticoneDropdownSaleCustomerName.SelectedValue.ToString(), out int customerId) || customerId <= 0)
            {
                MessageBox.Show("Customer selection is invalid.", "Validation Error");
                return;
            }

            using (var ctx = new InventoryContext(optionsBuilder.Options))
            {
                try
                {
                    // --- 2. Resolve Customer and Start Transaction ---
                    var customerName = siticoneDropdownSaleCustomerName.Text.Trim();
                    var customer = ctx.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                    if (customer == null)
                    {
                        MessageBox.Show($"Customer '{customerId}' not found.", "Database Error");
                        return;
                    }

                    // Start an EF Core transaction to ensure all database operations succeed or fail together
                    using (var transaction = ctx.Database.BeginTransaction())
                    {
                        // --- 3. Create Sale Header ---
                        var newSale = new Models.Sale // Ensure you reference your Sale Model correctly
                        {
                            CustomerID = customer.CustomerID,
                            SaleDate = DateTime.Now,
                            TotalAmount = _saleLines.Sum(l => l.Subtotal),
                            // Add other relevant fields (e.g., PaymentMethod if you have a control for it)
                        };

                        ctx.Sales.Add(newSale);
                        ctx.SaveChanges(); // Save to generate the new SaleID

                        // --- 4. Process Sale Items and Update Inventory ---
                        foreach (var line in _saleLines)
                        {
                            // a. Create SaleItem
                            var saleItem = new Models.SaleItem
                            {
                                SaleID = newSale.SaleID, // Use the ID generated above
                                ProductID = line.ProductID,
                                Quantity = line.Quantity,
                                Subtotal = line.Subtotal
                            };
                            ctx.SaleItems.Add(saleItem);

                            // b. Update Inventory/Product Stock
                            var productToUpdate = ctx.Products.FirstOrDefault(p => p.ProductsID == line.ProductID);

                            if (productToUpdate != null)
                            {
                                if (productToUpdate.StockQuantity < line.Quantity)
                                {
                                    // If stock is insufficient, rollback the entire transaction
                                    transaction.Rollback();
                                    MessageBox.Show($"Insufficient stock for {line.ProductName}. Available: {productToUpdate.StockQuantity}", "Inventory Error");
                                    return;
                                }

                                productToUpdate.StockQuantity -= line.Quantity;
                                ctx.Products.Update(productToUpdate);
                            }
                            else
                            {
                                // Product not found during item processing - this should ideally not happen
                                transaction.Rollback();
                                MessageBox.Show($"Product ID {line.ProductID} not found during processing.", "Internal Error");
                                return;
                            }
                        }

                        // --- 5. Final Save and Commit Transaction ---
                        ctx.SaveChanges(); // Save all SaleItems and Product updates
                        transaction.Commit(); // Make all changes permanent

                        MessageBox.Show("Sale successfully confirmed and inventory updated.", "Success");

                        // Clear state and close form
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the sale: {ex.Message}", "Database Error");
                    // Note: If an exception occurs, the 'using (var transaction...)' block will often handle rollback automatically, 
                    // but explicitly committing/rolling back within the try block ensures explicit control.
                }
            }
        }

        private void siticoneDataGridViewSaleItems_Load(object sender, EventArgs e)
        {
        }
    }
}
