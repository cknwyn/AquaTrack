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
        public ProductForm()
        {
            InitializeComponent();
        }

        private void siticoneButtonProductConfirm_Click(object sender, EventArgs e)
        {
            // check if necessary fields are filled
            if (string.IsNullOrWhiteSpace(siticoneTextBoxProductName.Text) ||
                string.IsNullOrWhiteSpace(siticoneUpDownProductPrice.Text) ||
                string.IsNullOrWhiteSpace(siticoneUpDownProductQuantity.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Fish")
            {
                if (string.IsNullOrWhiteSpace(siticoneDropdownWaterEnvironment.Text) ||
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
                    string.IsNullOrWhiteSpace(siticoneDropdownEquipmentType.SelectedItem))
                {
                    MessageBox.Show("Please fill in all required fields under equipment details.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (var context = new Data.InventoryContext(
                new DbContextOptionsBuilder<Data.InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options))
            {
                var existingProduct = context.Products
                    .FirstOrDefault(p => p.Name == siticoneTextBoxProductName.Text);
                if (existingProduct != null)
                {
                    MessageBox.Show("A product with this name already exists. Please choose a different name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                using (var context = new Data.InventoryContext(
                    new DbContextOptionsBuilder<Data.InventoryContext>()
                    .UseSqlite("Data Source=InventoryAndSales.db")
                    .Options))
                {
                    // Create and save product based on category
                    if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Fish")
                    {
                        var newFish = new Models.Fish
                        {
                            Name = name,
                            Price = price,
                            Category = category,
                            StockQuantity = stockQuantity,
                            SupplierID = supplierId,
                            DateAdded = DateTime.Now,
                            Species = siticoneTextBoxSpeciesName.Text,
                            Age = int.Parse(siticoneUpDownFishAge.Text),
                            WaterEnvironment = siticoneDropdownWaterEnvironment.SelectedItem.ToString()
                        };
                        context.Products.Add(newFish);

                        MessageBox.Show("Fish added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (siticoneDropdownProductCategory.SelectedItem.ToString() == "Equipment")
                    {
                        var newEquipment = new Models.Equipment
                        {
                            Name = name,
                            Price = price,
                            Category = category,
                            StockQuantity = stockQuantity,
                            SupplierID = supplierId,
                            DateAdded = DateTime.Now,
                            Brand = siticoneTextBoxEquipmentBrand.Text,
                            Model = siticoneTextBoxEquipmentModel.Text,
                            EquipmentType = siticoneDropdownEquipmentType.SelectedItem.ToString()
                        };
                        context.Products.Add(newEquipment);

                        MessageBox.Show("Equipment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    context.SaveChanges();
                    ProductControlRef?.refreshProductsList();
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

        private void siticoneButtonProductCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
