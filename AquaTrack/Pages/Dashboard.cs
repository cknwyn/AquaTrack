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
                        siticoneLabelDnCValues.Text = context.DamagedItems.Count().ToString();
                        siticoneLabelTasksValue.Text = context.TaskNotes.Count().ToString();
                    }
                }
                catch (Exception ex)
                {
                    siticoneLabelProductsValue.Text = "0";
                }
            };

            if (this.InvokeRequired)
                this.BeginInvoke(work);
            else
                work();
        }
    }

    public partial class ProductsControl
    {
        // Raised after product list changes (add, edit, delete).
        public event EventHandler? ProductsChanged;
        protected void OnProductsChanged()
        {
            ProductsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public partial class TasksControl
    {
        public event EventHandler? TasksChanged;
        protected void OnTasksChanged()
        {
            TasksChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public partial class DncControl
    {
        public event EventHandler? DncChanged;
        protected void OnDncChanged()
        {
            DncChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

