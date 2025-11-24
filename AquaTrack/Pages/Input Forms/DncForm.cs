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
        private int _damagedIdToEdit = 0;
        public DncForm() : this(0) { }
        public DncForm(int damagedId)
        {
            InitializeComponent();

            _damagedIdToEdit = damagedId;

            if (_damagedIdToEdit > 0)
            {
                this.Text = "Edit Damaged Record";
                LoadDncData(_damagedIdToEdit);
            }
            else
            {
                this.Text = "Report Damaged Item";
            }
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

            // Resolve selected product id from dropdown
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
            _ = SaveDamagedItemHandlerAsync(productId, damagedQty);
        }

        private async Task SaveDamagedItemHandlerAsync(int productId, int damagedQty)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            try
            {
                using (var ctx = new InventoryContext(optionsBuilder.Options))
                {
                    await SaveDamagedItem(ctx, productId, damagedQty);

                    MessageBox.Show($"Damaged item record successfully {(_damagedIdToEdit > 0 ? "updated" : "recorded")} and stock adjusted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh parent lists
                    ProductsControlRef?.refreshProductsList();
                    DamagedControlRef?.RefreshDncItems();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save damaged item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show(ex.InnerException?.Message); // Re-enable for debugging
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

        public async Task SaveDamagedItem(InventoryContext ctx, int productId, int damagedQty)
        {
            // The core stock manipulation logic is sensitive. For editing, we prevent major changes.
            if (_damagedIdToEdit > 0)
            {
                // === EDIT MODE ===
                var damagedRecord = await ctx.DamagedItems.FindAsync(_damagedIdToEdit);
                if (damagedRecord == null) throw new Exception("Record not found for update.");

                if (damagedRecord.Quantity != damagedQty || damagedRecord.ProductID != productId)
                {
                    throw new Exception("Cannot change Product or Quantity when editing DNC records. Please delete and re-add.");
                }

                // Update only the DateReported (or other non-stock fields)
                damagedRecord.DateReported = (DateTime)siticoneDateTimePicker1.Value;

                // Ensure entity is tracked
                ctx.DamagedItems.Update(damagedRecord);
            }
            else
            {
                // === ADD MODE (Original AddDamagedItem logic) ===
                var product = await ctx.Products.FirstOrDefaultAsync(p => p.ProductsID == productId);

                if (product == null) throw new Exception("Product not found in inventory.");

                if (product.StockQuantity < damagedQty)
                {
                    throw new Exception($"Insufficient stock ({product.StockQuantity} available) to report {damagedQty} damaged items.");
                }

                // Deduct stock
                product.StockQuantity -= damagedQty;

                // Create new record
                var damaged = new Damaged
                {
                    ProductID = product.ProductsID,
                    DamagedName = product.Name,
                    Quantity = damagedQty,
                    DateReported = (DateTime)siticoneDateTimePicker1.Value,
                };
                ctx.DamagedItems.Add(damaged);

                // Ensure product update is tracked
                ctx.Products.Update(product);
            }

            await ctx.SaveChangesAsync();
        }

        private async void LoadDncData(int damagedId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var ctx = new InventoryContext(options))
            {
                try
                {
                    var damagedRecord = await ctx.DamagedItems.FindAsync(damagedId);

                    if (damagedRecord == null)
                    {
                        MessageBox.Show("Damaged record not found.", "Error");
                        this.Close();
                        return;
                    }

                    // Populate fields
                    // Date time picker
                    siticoneDateTimePicker1.Value = damagedRecord.DateReported;

                    // Quantity (Assuming siticoneUpDownDamagedQuantity is the UpDown control)
                    var numericControl = Controls.Find("siticoneUpDownDamagedQuantity", true).FirstOrDefault() as SiticoneNetCoreUI.SiticoneUpDown;
                    if (numericControl != null)
                    {
                        numericControl.Value = damagedRecord.Quantity;
                    }

                    // Load the full list of products into the dropdown (needed before setting SelectedValue)
                    siticoneDropdownDamagedProduct_Click(null, null);

                    // Set the product dropdown to the stored ProductID
                    siticoneDropdownDamagedProduct.SelectedValue = damagedRecord.ProductID;

                    // Disable changing the product item during edit to keep stock deduction simpler
                    siticoneDropdownDamagedProduct.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load damaged record data: " + ex.Message, "Error");
                }
            }
        }

        private void siticoneButtonDamagedCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
