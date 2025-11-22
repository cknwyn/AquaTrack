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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void siticoneLinkedLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm Register = new RegisterForm();
            Register.Show();
        }

        private void siticoneBASignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm Main = new MainForm();
            Main.Show();
        }
    }
}
