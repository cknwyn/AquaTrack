using AquaTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaTrack
{
    public partial class LoginForm : Form
    {
        private readonly InventoryContext _context;
        public LoginForm(InventoryContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void siticoneLinkedLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm Register = new RegisterForm(_context);
            Register.Show();
        }

        private void siticoneBASignIn_Click(object sender, EventArgs e)
        {
            string username = siticoneTBAUsername.Text;
            string password = siticoneTBAPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.Username == username && user.Password == password)
                {
                    this.Hide();
                    MainForm Main = new MainForm();
                    Main.Show();
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to log in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
