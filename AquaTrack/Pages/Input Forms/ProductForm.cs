using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AquaTrack.Data;
using AquaTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Pages.Input_Forms
{
    public partial class ProductForm : Form
    {
        public ProductsControl ProductControlRef { get; set; }
        private int _productIdToEdit = 0;

        public ProductForm() : this(0) { }
        public ProductForm(int productId)
        {
            InitializeComponent();
            _productIdToEdit = productId;

            if (_productIdToEdit > 0)
            {
                this.Text = "Edit Existing Product";
            }
            else
            {
                this.Text = "Add New Product";
            }
        }

        private async void siticoneButtonProductConfirm_Click(object sender, EventArgs e)
        {
            // check if necessary fields are filled
            if (string.IsNullOrWhiteSpace(siticoneTextBoxProductName.Text) ||
                string.IsNullOrWhiteSpace(siticoneUpDownProductPrice.Text) ||
                string.IsNullOrWhiteSpace(siticoneUpDownProductQuantity.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneDropdownProductCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneUpDownProductPrice.Value < (decimal) 0.001)
            {
                MessageBox.Show("Please input a valid price for the product.");
                return;
            }

            if (siticoneDropdownProductCategory.SelectedItem == "Fish")
            {
                if (siticoneDropdownWaterEnvironment.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(siticoneUpDownFishAge.Text) ||
                    string.IsNullOrWhiteSpace(siticoneTextBoxSpeciesName.Text))
                {
                    MessageBox.Show("Please fill in all required fields under fish details.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Equipment")
            {
                if (string.IsNullOrWhiteSpace(siticoneTextBoxEquipmentBrand.Text) ||
                    string.IsNullOrWhiteSpace(siticoneTextBoxEquipmentModel.Text) ||
                    siticoneDropdownEquipmentType.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all required fields under equipment details.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string name = siticoneTextBoxProductName.Text;
            string category = siticoneDropdownProductCategory.SelectedItem.ToString();
            decimal price = decimal.Parse(siticoneUpDownProductPrice.Text);
            int stockQuantity = int.Parse(siticoneUpDownProductQuantity.Text);
            int supplierId;
            object selectedSupplierValue = siticoneDropdownProductSupplier.SelectedValue;
            if (selectedSupplierValue != null)
            {
                supplierId = (int)selectedSupplierValue;
            }
            else
            {
                MessageBox.Show("Please select a valid supplier.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Start Save/Update Logic ---
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            try
            {
                using (var context = new InventoryContext(options))
                {
                    if (_productIdToEdit == 0)
                    {
                        // === ADD NEW PRODUCT LOGIC (Modified to check uniqueness for NEW products only) ===
                        var existingProduct = await context.Products
                            .FirstOrDefaultAsync(p => p.Name == name);

                        if (existingProduct != null)
                        {
                            MessageBox.Show("A product with this name already exists. Please choose a different name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    Products productToSave;
                    string successMessage;

                    if (_productIdToEdit > 0)
                    {
                        // === EDIT MODE: Load and Update ===
                        productToSave = await context.Products.FindAsync(_productIdToEdit);
                        if (productToSave == null) throw new Exception("Product not found for editing.");

                        successMessage = "updated";
                    }
                    else
                    {
                        // === ADD MODE: Create New Instance ===
                        productToSave = category == "Fish" ? new Fish() : (Products)new Equipment();
                        context.Products.Add(productToSave); // Add only if new
                        successMessage = "added";
                    }

                    // --- Update Base Product Properties ---
                    productToSave.Name = name;
                    productToSave.Price = price;
                    productToSave.Category = category;
                    productToSave.StockQuantity = stockQuantity;
                    productToSave.SupplierID = supplierId;

                    // If new, set DateAdded; if editing, leave it (or update if needed)
                    if (_productIdToEdit == 0)
                    {
                        productToSave.DateAdded = DateTime.Now;
                    }

                    // --- Update Derived (Fish/Equipment) Properties ---
                    if (category == "Fish" && productToSave is Fish fishToSave)
                    {
                        fishToSave.Species = siticoneTextBoxSpeciesName.Text;
                        fishToSave.Age = int.Parse(siticoneUpDownFishAge.Text);
                        fishToSave.WaterEnvironment = siticoneDropdownWaterEnvironment.SelectedItem.ToString();
                    }
                    else if (category == "Equipment" && productToSave is Equipment equipmentToSave)
                    {
                        equipmentToSave.Brand = siticoneTextBoxEquipmentBrand.Text;
                        equipmentToSave.Model = siticoneTextBoxEquipmentModel.Text;
                        equipmentToSave.EquipmentType = siticoneDropdownEquipmentType.SelectedItem.ToString();
                    }

                    // Save changes (handles both Insert and Update)
                    await context.SaveChangesAsync();

                    ProductControlRef?.refreshProductsList();

                    MessageBox.Show($"Product successfully {successMessage}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
                return;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // Disable all specific fields initially
            siticoneTextBoxEquipmentBrand.Enabled = false;
            siticoneTextBoxEquipmentModel.Enabled = false;
            siticoneDropdownEquipmentType.Enabled = false;
            siticoneTextBoxSpeciesName.Enabled = false;
            siticoneUpDownFishAge.Enabled = false;
            siticoneDropdownWaterEnvironment.Enabled = false;

            // load suppliers into suppliers dropdown
            using (var supplierContext = new Data.InventoryContext(
                new DbContextOptionsBuilder<Data.InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options))
            {
                var suppliers = supplierContext.Suppliers
                    .Select(s => new { s.SupplierID, s.Name })
                    .ToList();

                siticoneDropdownProductSupplier.DataSource = suppliers;
                siticoneDropdownProductSupplier.DisplayMember = "Name";
                siticoneDropdownProductSupplier.ValueMember = "SupplierID";
            }

            if (_productIdToEdit > 0)
            {
                LoadProductData(_productIdToEdit);
            }
        }

        private void siticoneProductDropdownProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Discern between equipment or fish
            if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Fish")
            {
                siticoneTextBoxSpeciesName.Enabled = true;
                siticoneUpDownFishAge.Enabled = true;
                siticoneDropdownWaterEnvironment.Enabled = true;
                siticoneTextBoxEquipmentBrand.Enabled = false;
                siticoneTextBoxEquipmentModel.Enabled = false;
                siticoneDropdownEquipmentType.Enabled = false;
                siticoneTextBoxEquipmentBrand.Text = string.Empty;
                siticoneTextBoxEquipmentModel.Text = string.Empty;
                siticoneDropdownEquipmentType.SelectedItem = null;
            }
            else if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Equipment")
            {
                siticoneTextBoxEquipmentBrand.Enabled = true;
                siticoneTextBoxEquipmentModel.Enabled = true;
                siticoneDropdownEquipmentType.Enabled = true;
                siticoneTextBoxSpeciesName.Enabled = false;
                siticoneUpDownFishAge.Enabled = false;
                siticoneDropdownWaterEnvironment.Enabled = false;
                siticoneTextBoxSpeciesName.Text = string.Empty;
                siticoneUpDownFishAge.Value = 0;
                siticoneDropdownWaterEnvironment.SelectedItem = null;
            }
            else
            {
                siticoneTextBoxEquipmentBrand.Enabled = false;
                siticoneTextBoxEquipmentModel.Enabled = false;
                siticoneDropdownEquipmentType.Enabled = false;
                siticoneTextBoxSpeciesName.Enabled = false;
                siticoneUpDownFishAge.Enabled = false;
                siticoneDropdownWaterEnvironment.Enabled = false;
                siticoneTextBoxEquipmentBrand.Text = string.Empty;
                siticoneTextBoxEquipmentModel.Text = string.Empty;
                siticoneDropdownEquipmentType.SelectedItem = null;
                siticoneLabelFishAge.Text = string.Empty;
                siticoneTextBoxSpeciesName.Text = string.Empty;
                siticoneDropdownWaterEnvironment.SelectedItem = null;
            }
        }

        private void siticoneDropdownEquipmentType_Click(object sender, EventArgs e)
        {
            // load types
            List<string> equipmentTypes = new List<string>
            {
                "Filter",
                "Heater",
                "Light",
                "Air Pumps",
                "Air Stone",
                "Thermometers",
                "Gravel cleaners",
                "Water Test Kits",
                "Decorations",
                "Food Containers",
                "Nets",
                "Water pumps",
                "Water conditioners",
                "Fish Food",
                "Feeders",
                "Substrates",
                "Covers/Lids",
                "Aquarium Stands",
                "UV Sterilizers",
                "CO2 Systems"
            };
            siticoneDropdownEquipmentType.Items.Clear();
            foreach (var type in equipmentTypes)
            {
                siticoneDropdownEquipmentType.Items.Add(type);
            }
        }

        private async void LoadProductData(int productId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var ctx = new InventoryContext(options))
            {
                // Load the base product, including derived types (Fish/Equipment) if possible
                var product = await ctx.Products.FindAsync(productId);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error");
                    this.Close();
                    return;
                }

                // Populate base fields
                siticoneTextBoxProductName.Text = product.Name;
                siticoneUpDownProductPrice.Text = product.Price.ToString();
                siticoneUpDownProductQuantity.Text = product.StockQuantity.ToString();
                siticoneDropdownProductSupplier.SelectedValue = product.SupplierID;

                // Set category dropdown and trigger change event to enable/disable fields
                siticoneDropdownProductCategory.SelectedItem = product.Category;
                siticoneProductDropdownProductCategory_SelectedIndexChanged(null, null);

                // Populate specific fields based on category
                if (product.Category == "Fish" && product is Fish fish)
                {
                    siticoneTextBoxSpeciesName.Text = fish.Species;
                    siticoneUpDownFishAge.Text = fish.Age.ToString();
                    siticoneDropdownWaterEnvironment.SelectedItem = fish.WaterEnvironment;
                }
                else if (product.Category == "Equipment" && product is Equipment equipment)
                {
                    siticoneTextBoxEquipmentBrand.Text = equipment.Brand;
                    siticoneTextBoxEquipmentModel.Text = equipment.Model;
                    siticoneDropdownEquipmentType.SelectedItem = equipment.EquipmentType;
                }

                // Disable Name field during edit to prevent foreign key issues
                siticoneTextBoxProductName.Enabled = false;
            }
        }

        private void siticoneButtonProductCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
