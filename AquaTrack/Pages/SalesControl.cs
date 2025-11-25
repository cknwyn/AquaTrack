using AquaTrack.Data;
using AquaTrack.Models;
using AquaTrack.Pages.Input_Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        private InventoryContext _context;
        public SalesControl()
        {
            InitializeComponent();

            siticoneDataGridViewSale.GridView.SelectionChanged += siticoneDataGridViewSale_SelectionChanged;
        }

        private void siticoneBtnAddSale_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.SalesControlRef = this;
            salesForm.ShowDialog();
        }
        private void SalesControl_Load(object sender, EventArgs e)
        {
            LoadSalesAsync();
        }
        public async Task LoadSalesAsync(string searchTerm = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            // Reinitialize context if necessary
            _context = new InventoryContext(options);

            var salesQuery = _context.Sales.AsQueryable();

            var searchFilter = searchTerm?.Trim() ?? string.Empty;
            var isSearching = !string.IsNullOrWhiteSpace(searchFilter);

            // --- Apply Search Filter ---
            if (isSearching)
            {
                if (int.TryParse(searchFilter, out int id))
                {
                    // Search by SaleID or CustomerID if the search term is a number
                    salesQuery = salesQuery.Where(s => s.SaleID == id || s.CustomerID == id);
                }
                else
                {
                    // Search by PaymentMethod (or Customer Name if Customer entity was included)
                    // Note: Searching by Customer Name requires Eager Loading the Customer entity.
                    // For simplicity, we search PaymentMethod here.
                    salesQuery = salesQuery.Where(s => s.PaymentMethod.Contains(searchFilter));
                }
            }

            var salesList = await salesQuery.OrderBy(s => s.SaleID).ToListAsync();

            // Display results
            siticoneDataGridViewSale.DataSource = salesList;
            siticoneDataGridViewSale.Refresh();

            // Optional: Provide feedback if the search returned no results
            if (isSearching && salesList.Count == 0)
            {
                MessageBox.Show($"No sales found matching '{searchFilter}'.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public async void RefreshSales()
        {
            await LoadSalesAsync();
            OnSalesChanged();
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

        private async void siticoneBtnDeleteSale_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewSale.GridView.SelectedCells
         .Cast<DataGridViewCell>()
         .Select(c => c.RowIndex)
         .Distinct()
         .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more sale records to delete.", "Delete Sale", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected sale record(s)? This will also delete all associated sale items.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            try
            {
                // Use a new context instance inside the try block
                using var ctx = new InventoryContext(options);

                // 1. Start a transaction for atomicity
                using (var transaction = await ctx.Database.BeginTransactionAsync())
                {
                    var idsToDelete = new List<int>();

                    foreach (var rowIndex in selectedRowIndexes)
                    {
                        if (rowIndex < 0 || rowIndex >= siticoneDataGridViewSale.GridView.Rows.Count) continue;
                        var row = siticoneDataGridViewSale.GridView.Rows[rowIndex];

                        if (row.DataBoundItem is Models.Sale sale)
                        {
                            idsToDelete.Add(sale.SaleID);
                            continue;
                        }

                        // Fallback (less reliable, but kept for completeness): try to find SaleID cell
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                                (string.Equals(cell.OwningColumn.DataPropertyName, "SaleID", StringComparison.OrdinalIgnoreCase))) // Use DataPropertyName
                            {
                                idsToDelete.Add(parsed);
                                break;
                            }
                        }
                    }

                    if (idsToDelete.Count == 0)
                    {
                        MessageBox.Show("Could not determine SaleID for selected rows.", "Delete Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Process deletions
                    foreach (var saleId in idsToDelete.Distinct())
                    {
                        // A. Manually delete associated SaleItems first
                        var saleItemsToDelete = await ctx.SaleItems
                                                         .Where(si => si.SaleID == saleId)
                                                         .ToListAsync();
                        ctx.SaleItems.RemoveRange(saleItemsToDelete);

                        // B. Then delete the parent Sale record
                        var saleEntity = await ctx.Sales.FindAsync(saleId);
                        if (saleEntity != null)
                        {
                            ctx.Sales.Remove(saleEntity);
                        }
                    }

                    // 3. Save changes and commit transaction
                    await ctx.SaveChangesAsync();
                    await transaction.CommitAsync();

                    // 4. Reload and notify
                    RefreshSales();

                    MessageBox.Show("Selected sale record(s) and associated items deleted.", "Delete Sale", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting sale records: " + ex.Message, "Delete Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneBtnEditSale_Click(object sender, EventArgs e)
        {
            // 1. Validate a single row is selected
            if (siticoneDataGridViewSale.GridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one sale record to edit.", "Edit Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = siticoneDataGridViewSale.GridView.SelectedRows[0];

            // 2. Safely get the selected Sale object and its ID
            if (selectedRow.DataBoundItem is Models.Sale selectedSale)
            {
                int saleIdToEdit = selectedSale.SaleID;

                // 3. Open SalesForm, passing the SaleID to indicate Edit Mode
                SalesForm salesForm = new SalesForm(saleIdToEdit); // Use new constructor
                salesForm.SalesControlRef = this;
                salesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not identify the selected sale record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneButtonTextboxSearchSales_ButtonClick(object sender, SiticoneNetCoreUI.ButtonTextboxClickEventArgs e)
        {
            string searchTerm = siticoneButtonTextboxSearchSales?.Text?.Trim() ?? string.Empty;
            _ = LoadSalesAsync(searchTerm);
        }
    }
}
