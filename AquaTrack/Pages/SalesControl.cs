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
using Microsoft.EntityFrameworkCore;
using AquaTrack.Data;
using Microsoft.Extensions.Options;

namespace AquaTrack.Pages
{
    public partial class SalesControl : UserControl
    {
        private InventoryContext _context;
        public SalesControl()
        {
            InitializeComponent();

            siticoneDataGridViewSale.GridView.SelectionChanged += siticoneDataGridViewSale_SelectionChanged;
        }

        private void siticoneBtnAddSale_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }
        private void SalesControl_Load(object sender, EventArgs e)
        {
            LoadSalesAsync();
        }
        public async Task LoadSalesAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;
            _context = new InventoryContext(options);

            var salesList = await _context.Sales.OrderBy(s => s.SaleID).ToListAsync();
            siticoneDataGridViewSale.DataSource = salesList;
            siticoneDataGridViewSale.Refresh();
        }

        public async void RefreshSales()
        {
            await LoadSalesAsync();
        }

        private async void siticoneDataGridViewSale_SelectionChanged(object sender, EventArgs e)
        {
            // Clear the Sale Items grid if nothing is selected
            if (siticoneDataGridViewSale.GridView.SelectedRows.Count == 0)
            {
                siticoneDataGridViewSaleItems.DataSource = null;
                return;
            }

            // Get the selected row
            var selectedRow = siticoneDataGridViewSale.GridView.SelectedRows[0];

            // The DataBoundItem will be one of the Models.Sale objects
            if (selectedRow.DataBoundItem is Models.Sale selectedSale)
            {
                int saleId = selectedSale.SaleID;

                // Fetch the SaleItems using the SaleID
                var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                var options = optionsBuilder.UseSqlite("Data Source = InventoryAndSales.db").Options;

                using (var ctx = new InventoryContext(options))
                {
                    // Fetch SaleItems and Eager Load the related Product data (ProductName)
                    var saleItems = await ctx.SaleItems
                        .Include(si => si.Product) // Assuming you have a navigation property named 'Product' in SaleItem model
                        .Where(si => si.SaleID == saleId)
                        .Select(si => new // Project to a clean DTO/anonymous type for display
                        {
                            Item = si.Product.Name,
                            Quantity = si.Quantity,
                            Subtotal = si.Subtotal
                        })
                        .ToListAsync();

                    // Display the results in the Sale Items DataGridView
                    siticoneDataGridViewSaleItems.DataSource = saleItems;
                }
            }
        }
    }
}
