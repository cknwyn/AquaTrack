using System;
using System.Drawing;
using System.Windows.Forms;
using AquaTrack.Pages;
using SiticoneNetCoreUI;

namespace AquaTrack
{
    public partial class MainForm : Form
    {
        private Dashboard dashboardPage = new Dashboard();
        private ProductsControl productsPage = new ProductsControl();
        private SupplierControl supplierPage = new SupplierControl();
        private DncControl dncPage = new DncControl();

        public MainForm()
        {
            InitializeComponent();

            siticoneContentPanelMain.AddContentToView("Products", productsPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Suppliers", supplierPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Damage and Casualties", dncPage, DockStyle.Fill);

            siticoneContentPanelDashboard.AddContentToView("Dashboard", dashboardPage, DockStyle.Fill);
            siticoneContentPanelDashboard.NavigateToView("Dashboard");
            siticoneContentPanelMain.AfterNavigate += siticoneContentPanelMain_AfterNavigate;
        }

        private void siticoneContentPanelMain_AfterNavigate(object sender, EventArgs e)
        {
            // Handle navigation events
            if (siticoneNavbarMain.SelectedItem != null)
            {
                string selectedText = siticoneNavbarMain.SelectedItem.Text;
                switch (selectedText)
                {
                    case "Suppliers":
                        siticoneContentPanelMain.NavigateToView("Suppliers");
                        break;
                    case "Products":
                        siticoneContentPanelMain.NavigateToView("Products");
                        break;
                    case "Damage and Casualties":
                        siticoneContentPanelMain.NavigateToView("Damage and Casualties");
                        break;
                    case "Sales":
                        // Navigate to Sales if implemented
                        break;
                    case "Tasks":
                        // Navigate to Tasks if implemented
                        break;
                        // Add more cases as needed for other navigation items
                }
            }
        }
    }
}
