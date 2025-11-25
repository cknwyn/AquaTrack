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
        private int _customerIdToEdit = 0;
        public CustomersForm() : this(0) { }
        public CustomersForm(int customerId)
        {
            InitializeComponent();

            _customerIdToEdit = customerId;

            if (_customerIdToEdit > 0)
            {
                this.Text = "Edit Existing Customer";
                LoadCustomerData(_customerIdToEdit);
            }
            else
            {
                this.Text = "Add New Customer";
            }
        }

        private async void siticoneButtonCustomerConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(siticoneTextBoxCustomerName.Text))
            {
                MessageBox.Show("Customer name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!siticoneTextBoxCustomerName.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Customer name can only contain letters and spaces.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTextBoxCustomerEmail.Text.Contains("@") == false || siticoneTextBoxCustomerEmail.Text.Contains(".") == false)
            {
                MessageBox.Show("Customer Email must be valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (siticoneTextBoxCustomerContactNumber.Text.Length < 10 || siticoneTextBoxCustomerContactNumber.Text.Length > 10 || !siticoneTextBoxCustomerContactNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("Customer Contact Number must be valid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // end of validation

            string customerName = siticoneTextBoxCustomerName.Text;
            string customerEmail = siticoneTextBoxCustomerEmail.Text;
            string customerNumber = siticoneTextBoxCustomerContactNumber.Text;

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            try
            {
                using (var context = new InventoryContext(optionsBuilder.Options))
                {
                    Models.Customer customerToSave;
                    string successMessage;

                    if (_customerIdToEdit > 0)
                    {
                        // === EDIT MODE ===
                        customerToSave = await context.Customers.FindAsync(_customerIdToEdit);
                        if (customerToSave == null) throw new Exception("Customer not found for update.");
                        successMessage = "updated";
                    }
                    else
                    {
                        // === ADD MODE ===
                        // Check for unique name only if ADDING
                        var existingCustomer = await context.Customers
                            .FirstOrDefaultAsync(c => c.Name == customerName);
                        if (existingCustomer != null)
                        {
                            MessageBox.Show("A customer with this name already exists.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        customerToSave = new Models.Customer();
                        context.Customers.Add(customerToSave);
                        successMessage = "added";
                    }

                    // --- Update Properties (Applies to both Add and Edit) ---
                    customerToSave.Name = customerName;
                    customerToSave.Email = customerEmail;
                    customerToSave.ContactNumber = customerNumber;

                    await context.SaveChangesAsync();
                    CustomerControlRef?.refreshCustomersList();

                    MessageBox.Show($"Customer successfully {successMessage}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show(ex.InnerException?.Message ?? ex.Message); // Re-enable for debugging
            }
        }

        private async void LoadCustomerData(int customerId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var context = new InventoryContext(options))
            {
                try
                {
                    var customer = await context.Customers.FindAsync(customerId);

                    if (customer == null)
                    {
                        MessageBox.Show("Customer not found.", "Error");
                        this.Close();
                        return;
                    }

                    siticoneTextBoxCustomerName.Text = customer.Name;
                    siticoneTextBoxCustomerEmail.Text = customer.Email;
                    siticoneTextBoxCustomerContactNumber.Text = customer.ContactNumber;

                    // Name field should be read-only if editing, as name is often a key identifier.
                    siticoneTextBoxCustomerName.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load customer data: " + ex.Message, "Error");
                }
            }
        }

        private void siticoneButtonCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
