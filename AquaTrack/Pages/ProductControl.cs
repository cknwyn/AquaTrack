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
            // check if exactly one row is selected
            if (siticoneDataGridViewProducts.GridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one product record to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = siticoneDataGridViewProducts.GridView.SelectedRows[0];

            int productIdToEdit = -1;

            foreach (DataGridViewCell cell in selectedRow.Cells)
            {
                // Find the column bound to 'ProductID'
                if (cell.OwningColumn.DataPropertyName == "ProductID" || cell.OwningColumn.HeaderText == "ProductID")
                {
                    if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsedId))
                    {
                        productIdToEdit = parsedId;
                        break;
                    }
                }
            }

            if (productIdToEdit <= 0)
            {
                MessageBox.Show("Could not determine Product ID for the selected row. Ensure the ProductID column is available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // open the ProductForm in Edit Mode
            ProductForm productForm = new ProductForm(productIdToEdit); // Use the new constructor
            productForm.ProductControlRef = this;
            productForm.ShowDialog();
        }

        private async Task loadProductsAsync(string searchTerm = null)
        {
            // Use an empty string if null for filtering consistency
            var searchFilter = searchTerm?.Trim() ?? string.Empty;
            var isSearching = !string.IsNullOrWhiteSpace(searchFilter);

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using var ctx = new InventoryContext(options);

            // Fetch all products first
            var productsQuery = ctx.Products.OrderBy(p => p.ProductsID).AsQueryable();
            var fishQuery = ctx.Fish.OrderBy(f => f.ProductsID).AsQueryable();
            var equipmentQuery = ctx.Equipment.OrderBy(e => e.ProductsID).AsQueryable();

            // --- APPLY SEARCH FILTER ---
            if (isSearching)
            {
                // Filter the database queries by Product Name (case-insensitive)
                productsQuery = productsQuery.Where(p => p.Name.Contains(searchFilter));
                fishQuery = fishQuery.Where(f => f.Name.Contains(searchFilter));
                equipmentQuery = equipmentQuery.Where(e => e.Name.Contains(searchFilter));
            }

            // Execute queries to get lists
            var productsList = await productsQuery.ToListAsync();
            var fishList = await fishQuery.ToListAsync();
            var equipmentList = await equipmentQuery.ToListAsync();

            var filterText = siticoneDropdownProductFilter?.SelectedItem?.ToString() ?? string.Empty;
            var grid = siticoneDataGridViewProducts?.GridView;
            if (grid == null)
            {
                // fallback
                siticoneDataGridViewProducts.DataSource = productsList;
                siticoneDataGridViewProducts.AutoScroll = true;
                siticoneDataGridViewProducts.Refresh();
                return;
            }

            // Clear previous binding/columns
            grid.DataSource = null;
            grid.Columns.Clear();

            if (string.Equals(filterText, "Fish", StringComparison.OrdinalIgnoreCase))
            {
                // Project filtered fish list
                var fishView = fishList
                    .Select(f => new
                    {
                        ProductID = f.ProductsID,
                        f.Name,
                        f.Price,
                        f.StockQuantity,
                        f.Species,
                        f.Age,
                        WaterEnvironment = f.WaterEnvironment
                    })
                    .ToList();

                grid.AutoGenerateColumns = true;
                grid.DataSource = fishView;
            }
            else if (string.Equals(filterText, "Equipment", StringComparison.OrdinalIgnoreCase))
            {
                // Project filtered equipment list
                var equipView = equipmentList
                    .Select(e => new
                    {
                        ProductID = e.ProductsID,
                        e.Name,
                        e.Price,
                        e.StockQuantity,
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
                // Default: show basic product columns from the filtered list
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

            // Optional: Provide feedback if the search returned no results
            if (isSearching && grid.Rows.Count == 0)
            {
                MessageBox.Show($"No products found matching '{searchFilter}' in the selected category.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            string currentSearchTerm = siticoneButtonTextboxSearchProducts?.Text?.Trim() ?? string.Empty;
            await loadProductsAsync(currentSearchTerm);
        }

        private void siticoneButtonTextboxSearchProducts_TextContentChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButtonTextboxSearchProducts_ButtonClick(object sender, ButtonTextboxClickEventArgs e)
        {
            string searchTerm = siticoneButtonTextboxSearchProducts?.Text?.Trim() ?? string.Empty;
            _ = loadProductsAsync(searchTerm);
        }
    }
}
