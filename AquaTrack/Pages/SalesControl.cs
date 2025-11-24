using AquaTrack.Pages.Input_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaTrack.Pages
{
    public partial class SalesControl : UserControl
    {
        public SalesControl()
        {
            InitializeComponent();
        }

        private void siticoneBtnAddSale_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }
    }
}
