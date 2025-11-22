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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void siticoneBABack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm Login = new LoginForm();
            Login.Show();
        }
    }
}
