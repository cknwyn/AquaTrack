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
        public ProductsControl ProductControlRef { get; set; }
        public SalesControl SalesControlRef { get; set; }
        private BindingList<SaleLine> _saleLines = new BindingList<SaleLine>();
        private InventoryContext _context;

        private int _saleIdToEdit = 0;
        public struct SaleLine
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Subtotal { get; set; }
        }
        public SalesForm() : this(0) { }

        public SalesForm(int saleId)
        {
            InitializeComponent();

            _saleIdToEdit = saleId;

            siticoneDataGridViewSaleItem.GridView.AutoGenerateColumns = true;
            siticoneDataGridViewSaleItem.DataSource = _saleLines;

            if (_saleIdToEdit > 0)
            {
                this.Text = $"Edit Sale #{_saleIdToEdit}";
                // Load Customer dropdown first before setting SelectedValue
                siticoneDropdownSaleCustomerName_Click(null, null);
                LoadSaleData(_saleIdToEdit);
            }
            else
            {
                this.Text = "Add New Sale";
            }
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

        private async void siticoneButtonSaleConfirm_Click(object sender, EventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            // --- Validation (Unchanged) ---
            if (siticoneDropdownSaleCustomerName.SelectedValue == null || _saleLines.Count == 0)
            {
                MessageBox.Show("Please select a Customer and add at least one item.", "Validation Error");
                return;
            }
            if (!int.TryParse(siticoneDropdownSaleCustomerName.SelectedValue.ToString(), out int customerId) || customerId <= 0)
            {
                MessageBox.Show("Customer selection is invalid.", "Validation Error");
                return;
            }
            if (siticoneDropdownSalePaymentMethod.SelectedItem?.ToString() == null) // Check payment method
            {
                MessageBox.Show("Please choose a valid payment method", "Selection Error");
                return;
            }
            // --- End Validation ---

            using (var ctx = new InventoryContext(optionsBuilder.Options))
            {
                try
                {
                    Models.Sale saleToSave;

                    // 1. Start an EF Core transaction
                    using (var transaction = await ctx.Database.BeginTransactionAsync())
                    {
                        // 2. Load Customer
                        var customer = await ctx.Customers.FirstOrDefaultAsync(c => c.CustomerID == customerId);
                        if (customer == null) throw new Exception($"Customer '{customerId}' not found.");

                        // 3. Handle EDIT vs. NEW
                        if (_saleIdToEdit > 0)
                        {
                            // === EDIT MODE ===
                            saleToSave = await ctx.Sales
                                .Include(s => s.SaleItems)
                                .FirstOrDefaultAsync(s => s.SaleID == _saleIdToEdit);

                            if (saleToSave == null) throw new Exception("Sale record not found for update.");

                            // a. Revert stock for all OLD items
                            foreach (var oldItem in saleToSave.SaleItems)
                            {
                                var oldProduct = await ctx.Products.FindAsync(oldItem.ProductID);
                                if (oldProduct != null)
                                {
                                    oldProduct.StockQuantity += oldItem.Quantity; // Return stock
                                }
                            }

                            // b. Delete all old SaleItems
                            ctx.SaleItems.RemoveRange(saleToSave.SaleItems);
                            ctx.Sales.Update(saleToSave);
                        }
                        else
                        {
                            saleToSave = new Models.Sale();
                            ctx.Sales.Add(saleToSave);
                        }

                        // 4. Update Sale Header properties
                        saleToSave.CustomerID = customer.CustomerID;
                        saleToSave.SaleDate = (DateTime) siticoneDTPSaleDate.Value;
                        saleToSave.TotalAmount = _saleLines.Sum(l => l.Subtotal);
                        saleToSave.PaymentMethod = siticoneDropdownSalePaymentMethod.SelectedItem.ToString();

                        // Commit header (necessary if new to get SaleID, safe if editing)
                        await ctx.SaveChangesAsync();

                        // 5. Process NEW Sale Items and Update Inventory
                        foreach (var line in _saleLines)
                        {
                            // a. Validate stock BEFORE creating the item
                            var productToUpdate = await ctx.Products.FindAsync(line.ProductID);

                            if (productToUpdate == null) throw new Exception($"Product ID {line.ProductID} not found during processing.");

                            if (productToUpdate.StockQuantity < line.Quantity)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Insufficient stock for {line.ProductName}. Available: {productToUpdate.StockQuantity}", "Inventory Error");
                                return;
                            }

                            // b. Create new SaleItem
                            var saleItem = new Models.SaleItem
                            {
                                SaleID = saleToSave.SaleID,
                                ProductID = line.ProductID,
                                Quantity = line.Quantity,
                                UnitPrice = line.Price, // Use UnitPrice = Price from SaleLine
                                Subtotal = line.Subtotal
                            };
                            ctx.SaleItems.Add(saleItem);

                            // c. Deduct new stock quantity
                            productToUpdate.StockQuantity -= line.Quantity;
                            // ctx.Products.Update(productToUpdate); // EF Core tracks changes automatically
                        }

                        // 6. Final Save and Commit Transaction
                        await ctx.SaveChangesAsync();
                        await transaction.CommitAsync();

                        // Refresh main list and update dashboard totals after successful save
                        SalesControlRef?.RefreshSales();
                        // ProductControlRef?.UpdateSalesDashboardTotal(await SalesControlRef.GetOverallSalesGrandTotalAsync()); // Example dashboard update

                        MessageBox.Show($"Sale successfully {(_saleIdToEdit > 0 ? "updated" : "confirmed")} and inventory adjusted.", "Success");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the sale: {ex.Message}", "Database Error");
                }
            }
        }

        private void siticoneDataGridViewSaleItems_Load(object sender, EventArgs e)
        {
        }

        private async void LoadSaleData(int saleId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var ctx = new InventoryContext(options))
            {
                try
                {
                    var sale = await ctx.Sales
                        .Include(s => s.SaleItems)
                        .ThenInclude(si => si.Product)
                        .FirstOrDefaultAsync(s => s.SaleID == saleId);

                    if (sale == null) return;

                    // Populate Header Controls
                    siticoneDTPSaleDate.Value = sale.SaleDate;
                    siticoneDropdownSalePaymentMethod.SelectedItem = sale.PaymentMethod;
                    siticoneDropdownSaleCustomerName.SelectedValue = sale.CustomerID;

                    // Populate Sale Items Grid
                    _saleLines.Clear();
                    foreach (var item in sale.SaleItems)
                    {
                        _saleLines.Add(new SaleLine
                        {
                            ProductID = item.ProductID,
                            ProductName = item.Product.Name,
                            Quantity = item.Quantity,
                            Price = item.UnitPrice,
                            Subtotal = item.Subtotal
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load sale data: " + ex.Message, "Error");
                }
            }
        }
    }
}
