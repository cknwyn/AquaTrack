using AquaTrack.Data;
using AquaTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI;

namespace AquaTrack.Pages.Input_Forms
{
    public partial class DncForm : Form
    {
        public InventoryContext _context;
        public DncControl? DamagedControlRef { get; set; }
        public ProductsControl? ProductsControlRef { get; set; }
        public DncForm()
        {
            InitializeComponent();
        }


        private void siticoneButtonDamagedConfirm_Click(object sender, EventArgs e)
        {
            // Ensure DbContext is available for AddDamagedItem (AddDamagedItem expects _context to be set)
            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");
                _context = new InventoryContext(optionsBuilder.Options);
            }

            // Resolve selected product id from dropdown (works with ValueMember = "ProductsID")
            int productId = -1;
            try
            {
                // Preferred: SelectedValue contains the ProductsID
                if (siticoneDropdownDamagedProduct.SelectedValue != null &&
                    int.TryParse(siticoneDropdownDamagedProduct.SelectedValue.ToString(), out var parsedId))
                {
                    productId = parsedId;
                }
                else if (siticoneDropdownDamagedProduct.SelectedItem != null)
                {
                    // Fallback: SelectedItem is an anonymous type with ProductsID property (from earlier query)
                    var sel = siticoneDropdownDamagedProduct.SelectedItem;
                    var prop = sel.GetType().GetProperty("ProductsID") ?? sel.GetType().GetProperty("ProductID");
                    if (prop != null && int.TryParse(prop.GetValue(sel)?.ToString(), out parsedId))
                        productId = parsedId;
                }
            }
            catch
            {
                productId = -1;
            }

            if (productId <= 0)
            {
                MessageBox.Show("Please select a valid product.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get damaged quantity - try common controls then fall back to an input box.
            int damagedQty = 0;
            bool qtyParsed = false;

            // Try numeric control names people commonly use
            var numericControl = Controls.Find("siticoneUpDownDamagedQuantity", true).FirstOrDefault() as SiticoneNetCoreUI.SiticoneUpDown
                ?? Controls.Find("siticoneUpDownDamagedQuantity", true).FirstOrDefault() as SiticoneNetCoreUI.SiticoneUpDown;
            if (numericControl != null)
            {
                damagedQty = (int)numericControl.Value;
                qtyParsed = true;
            }

            // Final fallback: simple input box
            if (!qtyParsed)
            {
                var input = Interaction.InputBox("Enter damaged quantity:", "Damaged Quantity", "1");
                if (!int.TryParse(input.Trim(), out damagedQty))
                {
                    MessageBox.Show("Invalid quantity entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (damagedQty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Call the async helper and handle result/feedback
            _ = AddDamagedItemHandlerAsync(productId, damagedQty);
        }

        private async Task AddDamagedItemHandlerAsync(int productId, int damagedQty)
        {
            try
            {
                await AddDamagedItem(productId, damagedQty);
                MessageBox.Show("Damaged item recorded and stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally refresh any parent lists / controls here.
                ProductsControlRef?.refreshProductsList();
                DamagedControlRef?.RefreshDncItems();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to record damaged item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        private void siticoneDropdownDamagedProduct_Click(object sender, EventArgs e)
        {
            // load list of products
            using (var context = new Data.InventoryContext(
                new DbContextOptionsBuilder<Data.InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options))
            {
                var products = context.Products
                    .Select(p => new { p.ProductsID, p.Name })
                    .ToList();

                siticoneDropdownDamagedProduct.DataSource = products;
                siticoneDropdownDamagedProduct.DisplayMember = "Name";
                siticoneDropdownDamagedProduct.ValueMember = "ProductsID";
            }
        }

        public async Task AddDamagedItem(int productId, int damagedQty)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductsID == productId);

            if (product == null) return;

            if (product.StockQuantity < damagedQty) return;

            product.StockQuantity = product.StockQuantity - damagedQty;

            var damaged = new Damaged
            {
                ProductID = product.ProductsID,
                DamagedName = product.Name,
                Quantity = damagedQty,
                DateReported = (DateTime) siticoneDateTimePicker1.Value,
            };

            _context.DamagedItems.Add(damaged);
            await _context.SaveChangesAsync();
            ProductsControlRef?.refreshProductsList();
        }
    }
}
