using AquaTrack.Data;
using AquaTrack.Models;
using AquaTrack.Pages.Input_Forms;
using Microsoft.EntityFrameworkCore;
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
    public partial class SupplierControl : UserControl
    {
        private InventoryContext _context;
        public SupplierControl()
        {
            InitializeComponent();
        }

        private void siticoneBtnAddSupplier_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.SupplierControlRef = this;
            suppliersForm.ShowDialog();
        }

        private void SupplierControl_Load(object sender, EventArgs e)
        {
            loadSuppliersAsync();
        }

        private async Task loadSuppliersAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;
            _context = new InventoryContext(options);

            var suppliersList = await _context.Suppliers.OrderBy(s => s.SupplierID).ToListAsync();
            siticoneDataGridViewSupplier.DataSource = suppliersList;
            siticoneDataGridViewSupplier.Refresh();
        }

        public async void refreshSupplierList()
        {
            await loadSuppliersAsync();
        }

        private async void siticoneBtnDeleteSupplier_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewSupplier.GridView.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more suppliers to delete.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected supplier(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    if (rowIndex < 0 || rowIndex >= siticoneDataGridViewSupplier.GridView.Rows.Count) continue;
                    var row = siticoneDataGridViewSupplier.GridView.Rows[rowIndex];

                    if (row.DataBoundItem is Supplier s)
                    {
                        idsToDelete.Add(s.SupplierID);
                        continue;
                    }

                    // fallback: try to find a ProductsID cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                            (string.Equals(cell.OwningColumn.Name, "SupplierID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.HeaderText, "SupplierID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.Name, "ID", StringComparison.OrdinalIgnoreCase)))
                        {
                            idsToDelete.Add(parsed);
                            break;
                        }
                    }
                }

                if (idsToDelete.Count == 0)
                {
                    MessageBox.Show("Could not determine SupplierID for selected rows.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var id in idsToDelete.Distinct())
                {
                    var entity = await _context.Suppliers.FindAsync(id);
                    if (entity != null)
                        _context.Suppliers.Remove(entity);
                }

                await _context.SaveChangesAsync();

                // reload and notify
                refreshSupplierList();

                MessageBox.Show("Selected supplier(s) deleted.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier: " + ex.Message, "Delete supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneBtnEditSupplier_Click(object sender, EventArgs e)
        {

        }
    }
}
