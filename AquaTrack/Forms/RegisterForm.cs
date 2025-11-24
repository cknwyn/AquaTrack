using AquaTrack.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaTrack
{
    public partial class RegisterForm : Form
    {
        private readonly InventoryContext _context;
        public RegisterForm(InventoryContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void siticoneBABack_Click(object sender, EventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=Inventory.db");

            InventoryContext context = new InventoryContext(optionsBuilder.Options);

            this.Hide();
            LoginForm Login = new LoginForm(context);
            Login.Show();
        }

        private void siticoneBASignUp_Click(object sender, EventArgs e)
        {
            string email = siticoneTBAEmail.Text;
            string username = siticoneTBARegisterUsername.Text;
            string password = siticoneTBARegisterPassword.Text;
            string confirmPassword = siticoneTBAConfirmPassword.Text;

            if (siticoneTBAEmail.Text.Contains("@") == false || siticoneTBAEmail.Text.Contains(".") == false)
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if password is within minimum requirements

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (siticoneTBARegisterPassword.ValidationEnabled && !siticoneTBARegisterPassword.IsValid)
            {
                MessageBox.Show("Password must have at least 8 characters containing at least 1 number, 1 symbol, 1 uppercase letter, and 1 lowercase letter,", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");
                using (var context = new InventoryContext(optionsBuilder.Options))
                {
                    var existingUser = context.Users.FirstOrDefault(u => u.Username == username);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var newUser = new Models.User
                    {
                        Email = email,
                        Username = username,
                        Password = password,
                        Role = "Admin"
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm Login = new LoginForm(new InventoryContext(optionsBuilder.Options));
                Login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
