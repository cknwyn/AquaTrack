using AquaTrack.Data;
using AquaTrack.Pages.Input_Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Pages
{
    public partial class Dashboard : UserControl
    {
        private readonly InventoryContext _context;
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

        private void siticoneLabelProductsValue_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // set values for all labels in dashboard on initial load
            RefreshCounts();
        }

        // Public method to refresh the dashboard counters (safe for calling from any thread)
        public void RefreshCounts()
        {
            // Query the DB and set the label on the UI thread
            Action work = () =>
            {
                try
                {
                    using (var context = new Data.InventoryContext(
                           new DbContextOptionsBuilder<Data.InventoryContext>()
                           .UseSqlite("Data Source=InventoryAndSales.db")
                           .Options))
                    {
                        siticoneLabelProductsValue.Text = context.Products.Count().ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Optionally log the error. Do not crash the UI.
                    // For now, show a simple fallback value.
                    siticoneLabelProductsValue.Text = "0";
                }
            };

            if (this.InvokeRequired)
                this.BeginInvoke(work);
            else
                work();
        }
    }

    // Partial class to add an event without changing the designer-generated file.
    public partial class ProductsControl
    {
        // Raised after product list changes (add, edit, delete).
        public event EventHandler? ProductsChanged;

        // Call this method from within ProductsControl after you successfully add/edit/delete a product.
        protected void OnProductsChanged()
        {
            ProductsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
