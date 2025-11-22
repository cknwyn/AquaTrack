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
        private SalesControl salesPage = new SalesControl();
        private CustomersControl customersPage = new CustomersControl();
        private DncControl dncPage = new DncControl();
        private TasksControl tasksPage = new TasksControl();

        public MainForm()
        {
            InitializeComponent();

            siticoneContentPanelMain.AddContentToView("Products", productsPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Suppliers", supplierPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Damage and Casualties", dncPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Sales", salesPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Customers", customersPage, DockStyle.Fill);
            siticoneContentPanelMain.AddContentToView("Tasks", tasksPage, DockStyle.Fill);

            siticoneContentPanelDashboard.AddContentToView("Dashboard", dashboardPage, DockStyle.Fill);

            this.Load += MainForm_Load;
            siticoneContentPanelMain.AfterNavigate += siticoneContentPanelMain_AfterNavigate;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initial navigation to Dashboard
            siticoneContentPanelDashboard.NavigateToView("Dashboard");
            siticoneContentPanelDashboard.BringToFront();
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
                        siticoneContentPanelMain.NavigateToView("Sales");
                        break;
                    case "Tasks":
                        siticoneContentPanelMain.NavigateToView("Tasks");
                        break;
                    case "Customers":
                        siticoneContentPanelMain.NavigateToView("Customers");
                        break;
                    case "Logout":
                        var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Close();
                            
                        }
                        break;
                }
            }
        }
    }
}
