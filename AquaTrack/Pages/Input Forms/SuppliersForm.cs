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
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void siticoneButtonSupplierConfirm_Click(object sender, EventArgs e)
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

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");
                using (var context = new InventoryContext(optionsBuilder.Options))
                {
                    var newSupplier = new Models.Supplier
                    {
                        Name = supplierName,
                        Email = supplierEmail,
                        Address = supplierAddress,
                        ContactNumber = supplierContactNumber,
                        Notes = supplierNotes
                    };

                    context.Suppliers.Add(newSupplier);
                    context.SaveChanges();
                    SupplierControlRef?.refreshSupplierList();
                }
                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
            // refresh table
        }
    }
}
