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
    public partial class SaleItemsForm : Form
    {
        private InventoryContext _context;

        // Expose created line so the parent SalesForm can read it after dialog closes
        public SalesForm.SaleLine? CreatedLine { get; private set; }
        private SalesForm.SaleLine? _originalLine;

        public SaleItemsForm()
        {
            InitializeComponent();
        }

        public SaleItemsForm(SalesForm.SaleLine lineToEdit) : this()
        {
            _originalLine = lineToEdit;
            this.Text = "Edit Sale Item";

            // Disable product selection when editing (as this changes the whole item)
            siticoneDropdownSaleItemProduct.Enabled = false;

            // set Quantity
            siticoneUpDown1.Value = lineToEdit.Quantity;

            // set Product
            siticoneDropdownSaleItemProduct.Text = lineToEdit.ProductName;
            siticoneDropdownSaleItemProduct.SelectedValue = lineToEdit.ProductID;
        }

        private void siticoneButtonSaleItemCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void siticoneDropdownSaleItemProduct_Click(object sender, EventArgs e)
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options;

            using var ctx = new InventoryContext(options);

            // Bind products as DataSource so we can read SelectedValue (ProductsID)
            var products = ctx.Products.OrderBy(p => p.Name).ToList();
            siticoneDropdownSaleItemProduct.DataSource = products;
            siticoneDropdownSaleItemProduct.DisplayMember = "Name";
            siticoneDropdownSaleItemProduct.ValueMember = "ProductsID";
            siticoneDropdownSaleItemProduct.SelectedIndex = -1;
        }

        private void siticoneButtonSaleItemConfirm_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (siticoneDropdownSaleItemProduct.SelectedItem == null && string.IsNullOrWhiteSpace(siticoneDropdownSaleItemProduct.Text))
            {
                MessageBox.Show("Please select a product", "Error");
                return;
            }

            if (!int.TryParse(siticoneUpDown1.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity", "Error");
                return;
            }

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            // Resolve product id from SelectedValue (preferred) or lookup by name as fallback
            int productId = -1;
            if (siticoneDropdownSaleItemProduct.SelectedValue is int idVal)
            {
                productId = idVal;
            }
            else
            {
                var name = siticoneDropdownSaleItemProduct.Text.Trim();
                using (var ctxLookup = new InventoryContext(optionsBuilder.Options))
                {
                    var p = ctxLookup.Products.FirstOrDefault(p2 => p2.Name == name);
                    if (p != null) productId = p.ProductsID;
                }
            }

            if (productId <= 0)
            {
                MessageBox.Show("Selected product not found", "Error");
                return;
            }

            // Load the product to get current price and validate exists
            using (var ctx = new InventoryContext(optionsBuilder.Options))
            {
                var product = ctx.Products.FirstOrDefault(p => p.ProductsID == productId);

                // --- Determine Stock Adjustment needed for Edit Mode ---
                int stockAdjustment = quantity; // Quantity to deduct for new/edited item

                // If editing, factor in the quantity of the original line
                if (_originalLine.HasValue)
                {
                    // The net deduction is: (new quantity) - (old quantity)
                    stockAdjustment = quantity - _originalLine.Value.Quantity;
                }

                // Perform stock check against the net adjustment
                if (product.StockQuantity < stockAdjustment)
                {
                    MessageBox.Show($"Stock check failed. Net change requires {stockAdjustment} more units. Available stock is {product.StockQuantity}.", "Inventory Error");
                    return;
                }

                // Create the new SaleLine DTO
                CreatedLine = new SalesForm.SaleLine
                {
                    ProductID = product.ProductsID,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    Subtotal = product.Price * quantity
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
