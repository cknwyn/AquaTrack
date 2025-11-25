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
    public partial class DncControl : UserControl
    {
        // remove or keep this field but do NOT assign it inside a `using` block
        private InventoryContext _context;

        public DncControl()
        {
            InitializeComponent();
        }

        private void siticoneBtnAddDnc_Click(object sender, EventArgs e)
        {
            DncForm dncForm = new DncForm();
            dncForm.DamagedControlRef = this;
            dncForm.ShowDialog();
        }

        private void DncControl_Load(object sender, EventArgs e)
        {
            // Load DNC items into the DataGridView when the control loads
            _ = LoadDncItems();
        }

        private async Task LoadDncItems()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            // Use a local context so we don't leave a disposed instance in the field
            using var ctx = new InventoryContext(options);
            var dncItems = await Task.Run(() => ctx.DamagedItems
                .Select(d => new
                {
                    d.DamagedID,
                    d.DamagedName,
                    d.Quantity,
                    d.DateReported
                })
                .ToList());
            siticoneDataGridViewDnc.DataSource = dncItems;
        }

        public async Task RefreshDncItems()
        {
            await LoadDncItems();
            OnDncChanged();
        }

        private async void siticoneBtnDeleteDnc_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewDnc.GridView.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more records to delete.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected record(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
                var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

                // Use a local context for the delete operation
                using var ctx = new InventoryContext(options);

                var idsToDelete = new List<int>();

                foreach (var rowIndex in selectedRowIndexes)
                {
                    if (rowIndex < 0 || rowIndex >= siticoneDataGridViewDnc.GridView.Rows.Count) continue;
                    var row = siticoneDataGridViewDnc.GridView.Rows[rowIndex];

                    if (row.DataBoundItem is Damaged d)
                    {
                        idsToDelete.Add(d.DamagedID);
                        continue;
                    }

                    // fallback: try to find an ID cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                            (string.Equals(cell.OwningColumn.Name, "DamagedID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.HeaderText, "DamagedID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.Name, "ID", StringComparison.OrdinalIgnoreCase)))
                        {
                            idsToDelete.Add(parsed);
                            break;
                        }
                    }
                }

                if (idsToDelete.Count == 0)
                {
                    MessageBox.Show("Could not determine DamagedID for selected rows.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var id in idsToDelete.Distinct())
                {
                    var entity = await ctx.DamagedItems.FindAsync(id);
                    if (entity != null)
                        ctx.DamagedItems.Remove(entity);
                }

                await ctx.SaveChangesAsync();

                // reload and notify
                await RefreshDncItems();

                MessageBox.Show("Selected record(s) deleted.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneBtnEditDnc_Click(object sender, EventArgs e)
        {
            // validate a single row is selected
            if (siticoneDataGridViewDnc.GridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one damaged item record to edit.", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = siticoneDataGridViewDnc.GridView.SelectedRows[0];

            int damagedIdToEdit = -1;

            // Attempt to get ID from DataBoundItem if it was castable
            if (selectedRow.DataBoundItem is Models.Damaged selectedDnc)
            {
                damagedIdToEdit = selectedDnc.DamagedID;
            }
            // Fallback: Read the 'DamagedID' cell value from the anonymous object's column
            else if (selectedRow.Cells["DamagedID"] != null &&
                     int.TryParse(selectedRow.Cells["DamagedID"].Value?.ToString(), out int parsedId))
            {
                damagedIdToEdit = parsedId;
            }

            if (damagedIdToEdit <= 0)
            {
                MessageBox.Show("Could not determine Damaged ID for the selected record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // open DncForm, passing the DamagedID to indicate Edit Mode
            DncForm dncForm = new DncForm(damagedIdToEdit);
            dncForm.DamagedControlRef = this;
            dncForm.ShowDialog();
        }
    }
}
