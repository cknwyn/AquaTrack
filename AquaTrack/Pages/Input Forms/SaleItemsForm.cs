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

        public SaleItemsForm()
        {
            InitializeComponent();
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
                if (product == null)
                {
                    MessageBox.Show("Selected product not found in database", "Error");
                    return;
                }

                // Do NOT persist a SaleItem here — the SaleItems should be collected by the parent SalesForm,
                // and the Sale + SaleItems persisted together. Instead create a DTO line and return it.
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
