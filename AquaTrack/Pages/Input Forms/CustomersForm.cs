using AquaTrack.Data;
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
    public partial class CustomersForm : Form
    {
        private InventoryContext _context;
        public CustomersControl CustomerControlRef { get; set; }
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void siticoneButtonCustomerConfirm_Click(object sender, EventArgs e)
        {
            if (siticoneTextBoxCustomerName.Text == "")
            {
                MessageBox.Show("Customer name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTextBoxCustomerEmail.Text.Contains("@") == false || siticoneTextBoxCustomerEmail.Text.Contains(".") == false)
            {
                MessageBox.Show("Customer Email must be valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (siticoneTextBoxCustomerContactNumber.Text.Length < 10 || !siticoneTextBoxCustomerContactNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("Customer Contact Number must be valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string customerName = siticoneTextBoxCustomerName.Text;
            string customerEmail = siticoneTextBoxCustomerEmail.Text;
            string customerNumber = siticoneTextBoxCustomerContactNumber.Text;

            try
                {
                    var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                    optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");
                    using (var context = new InventoryContext(optionsBuilder.Options))
                    {
                        var newCustomer = new Models.Customer
                        {
                            Name = customerName,
                            Email = customerEmail,
                            ContactNumber = customerNumber
                        };

                        context.Customers.Add(newCustomer);
                        context.SaveChanges();
                        CustomerControlRef?.refreshCustomersList();
                    }
                    MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
                }
            }

        private void siticoneButtonCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
