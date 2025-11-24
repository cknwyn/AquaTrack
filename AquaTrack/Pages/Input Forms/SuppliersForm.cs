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
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Pages.Input_Forms
{
    public partial class SuppliersForm : Form
    {
        public SupplierControl SupplierControlRef { get; set; }
        private int _supplierIdToEdit = 0;
        public SuppliersForm() : this(0) { }
        public SuppliersForm(int supplierId)
        {
            InitializeComponent();
            _supplierIdToEdit = supplierId;

            if (_supplierIdToEdit > 0)
            {
                this.Text = "Edit Existing Supplier";
                LoadSupplierData(_supplierIdToEdit);
            }
            else
            {
                this.Text = "Add New Supplier";
            }
        }

        private async void siticoneButtonSupplierConfirm_Click(object sender, EventArgs e)
        {
            if (siticoneTextAreaSupplierNotes.Text.Length > 500)
            {
                MessageBox.Show("Supplier notes cannot exceed 500 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTextBoxSupplierAddress.Text == "")
            {
                MessageBox.Show("Supplier address cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTextBoxSupplierName.Text == "")
            {
                MessageBox.Show("Supplier name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTBASupplierEmail.Text.Contains("@") == false || siticoneTBASupplierEmail.Text.Contains(".") == false)
            {
                MessageBox.Show("Supplier Email must be valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string supplierName = siticoneTextBoxSupplierName.Text;
            string supplierEmail = siticoneTBASupplierEmail.Text;
            string supplierAddress = siticoneTextBoxSupplierAddress.Text;
            string supplierContactNumber = siticoneTBASupplierContactNumber.Text;
            string supplierNotes = siticoneTextAreaSupplierNotes.Text;

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            try
            {
                using (var context = new InventoryContext(optionsBuilder.Options))
                {
                    Models.Supplier supplierToSave;
                    string successMessage;

                    if (_supplierIdToEdit > 0)
                    {
                        // === EDIT MODE ===
                        supplierToSave = await context.Suppliers.FindAsync(_supplierIdToEdit);
                        if (supplierToSave == null) throw new Exception("Supplier not found for update.");
                        successMessage = "updated";
                    }
                    else
                    {
                        // === ADD MODE ===

                        // Check for unique name only if ADDING
                        var existingSupplier = await context.Suppliers
                            .FirstOrDefaultAsync(s => s.Name == supplierName);
                        if (existingSupplier != null)
                        {
                            MessageBox.Show("A supplier with this name already exists.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        supplierToSave = new Models.Supplier();
                        context.Suppliers.Add(supplierToSave);
                        successMessage = "added";
                    }

                    // --- Update Properties (applies to both Add and Edit) ---
                    // If editing, the Name property is likely read-only, but we update it just in case.
                    supplierToSave.Name = supplierName;
                    supplierToSave.Email = supplierEmail;
                    supplierToSave.Address = supplierAddress;
                    supplierToSave.ContactNumber = supplierContactNumber;
                    supplierToSave.Notes = supplierNotes;

                    await context.SaveChangesAsync();
                    SupplierControlRef?.refreshSupplierList();

                    MessageBox.Show($"Supplier successfully {successMessage}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show(ex.InnerException?.Message ?? ex.Message); // Re-enable if needed for debugging
            }
        }
        private async void LoadSupplierData(int supplierId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var context = new InventoryContext(options))
            {
                try
                {
                    var supplier = await context.Suppliers.FindAsync(supplierId);

                    if (supplier == null)
                    {
                        MessageBox.Show("Supplier not found.", "Error");
                        this.Close();
                        return;
                    }

                    siticoneTextBoxSupplierName.Text = supplier.Name;
                    siticoneTBASupplierEmail.Text = supplier.Email;
                    siticoneTextBoxSupplierAddress.Text = supplier.Address;
                    siticoneTBASupplierContactNumber.Text = supplier.ContactNumber;
                    siticoneTextAreaSupplierNotes.Text = supplier.Notes;

                    // Name field should be read-only if editing, as name is often a key identifier.
                    siticoneTextBoxSupplierName.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load supplier data: " + ex.Message, "Error");
                }
            }
        }
    }
}
