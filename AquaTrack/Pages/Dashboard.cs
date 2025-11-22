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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void siticoneBtnGenerateReport_Click(object sender, EventArgs e)
        {
            // show report form
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }
    }
}
