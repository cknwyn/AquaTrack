using AquaTrack.Data;
using AquaTrack.Models;
using AquaTrack.Pages.Input_Forms;
using Microsoft.EntityFrameworkCore;
using SiticoneNetCoreUI;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AquaTrack.Pages
{
    public partial class ProductsControl : UserControl
    {
        private InventoryContext _context;
        public ProductsControl()
        {
            InitializeComponent();
            _ = loadProductsAsync();
        }

        private async void siticoneBtnDeleteProduct_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewProducts.GridView.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more products to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected product(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (_context == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                    var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;
                    _context = new InventoryContext(options);
                }

                var idsToDelete = new List<int>();

                foreach (var rowIndex in selectedRowIndexes)
                {
                    if (rowIndex < 0 || rowIndex >= siticoneDataGridViewProducts.GridView.Rows.Count) continue;
                    var row = siticoneDataGridViewProducts.GridView.Rows[rowIndex];

                    if (row.DataBoundItem is Products p)
                    {
                        idsToDelete.Add(p.ProductsID);
                        continue;
                    }

                    // fallback: try to find a ProductsID cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                            (string.Equals(cell.OwningColumn.Name, "ProductID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.HeaderText, "ProductID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.Name, "ID", StringComparison.OrdinalIgnoreCase)))
                        {
                            idsToDelete.Add(parsed);
                            break;
                        }
                    }
                }

                if (idsToDelete.Count == 0)
                {
                    MessageBox.Show("Could not determine ProductsID for selected rows.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var id in idsToDelete.Distinct())
                {
                    var entity = await _context.Products.FindAsync(id);
                    if (entity != null)
                        _context.Products.Remove(entity);
                }

                await _context.SaveChangesAsync();

                // reload and notify
                refreshProductsList();

                MessageBox.Show("Selected product(s) deleted.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting products: " + ex.Message, "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneBtnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.ProductControlRef = this;
            productForm.ShowDialog();
        }

        private void siticoneBtnEditProduct_Click(object sender, EventArgs e)
        {

        }

        // centralized loader: pick the correct list once, set the actual visible GridView's DataSource
        private async Task loadProductsAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using var ctx = new InventoryContext(options);

            var productsList = await ctx.Products.OrderBy(p => p.ProductsID).ToListAsync();
            var fishList = await ctx.Fish.OrderBy(f => f.ProductsID).ToListAsync();
            var equipmentList = await ctx.Equipment.OrderBy(e => e.ProductsID).ToListAsync();

            var filterText = siticoneDropdownProductFilter?.Text?.Trim() ?? string.Empty;
            var grid = siticoneDataGridViewProducts?.GridView;
            if (grid == null)
            {
                // fallback
                siticoneDataGridViewProducts.DataSource = productsList;
                siticoneDataGridViewProducts.Refresh();
                return;
            }

            // Clear previous binding/columns and avoid stale PropertyDescriptors
            grid.DataSource = null;
            grid.Columns.Clear();

            if (string.Equals(filterText, "Fish", StringComparison.OrdinalIgnoreCase))
            {
                // Project exactly the columns you want for fish
                var fishView = fishList
                    .Select(f => new
                    {
                        ProductID = f.ProductsID,
                        f.Name,
                        f.Species,
                        WaterEnvironment = f.WaterEnvironment
                    })
                    .ToList();

                grid.AutoGenerateColumns = true;
                grid.DataSource = fishView;
            }
            else if (string.Equals(filterText, "Equipment", StringComparison.OrdinalIgnoreCase))
            {
                // Project exactly the columns you want for equipment
                var equipView = equipmentList
                    .Select(e => new
                    {
                        Type = e.EquipmentType,
                        e.Brand,
                        e.Model
                    })
                    .ToList();

                grid.AutoGenerateColumns = true;
                grid.DataSource = equipView;
            }
            else
            {
                // Default: show basic product columns
                var prodView = productsList
                    .Select(p => new
                    {
                        ProductID = p.ProductsID,
                        p.Name,
                        p.Category,
                        p.Price,
                        p.StockQuantity
                    })
                    .ToList();

                grid.AutoGenerateColumns = true;
                grid.DataSource = prodView;
            }

            grid.Refresh();
        }

        // modern refresh wrapper callers can await if needed
        public async Task RefreshProductsListAsync()
        {
            await loadProductsAsync();
            OnProductsChanged();
        }

        // keep the legacy method for existing callers but forward to async Task
        public async void refreshProductsList()
        {
            await RefreshProductsListAsync();
        }

        // make event handler async so it awaits reload and uses the same loader
        private async void siticoneDropdownProductFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadProductsAsync();
        }
    }
}
