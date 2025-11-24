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
using Windows.UI;

namespace AquaTrack.Pages
{
    public partial class TasksControl : UserControl
    {
        private InventoryContext _context;
        private readonly DataGridView _grid;
        private BindingList<TaskNotes> _bindingList = new();
        private readonly string _connectionString = "Data Source=InventoryAndSales.db";
        public TasksControl()
        {
            InitializeComponent();

            _grid = siticoneDataGridViewTasks.GridView;
            _grid.EditMode = DataGridViewEditMode.EditOnEnter;
            _grid.AllowUserToAddRows = false;
            //_grid.AutoGenerateColumns = false;

            _grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
            _grid.CellValueChanged += Grid_CellValueChanged;
        }

        private void Grid_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            // Ensure we are in a checkbox column before forcing the commit
            if (_grid.IsCurrentCellDirty)
            {
                // Check if the current column is the 'Status' column (the checkbox column)
                if (_grid.CurrentCell.OwningColumn.Name == "Status")
                {
                    // Force the grid to finalize the edit and update the bound data source
                    _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private async void Grid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            // 1. Only care about the Status column changes
            if (e.RowIndex < 0 || _grid.Columns[e.ColumnIndex].Name != "Status") return;

            // 2. Retrieve the updated model from the binding list
            if (e.RowIndex >= 0 && e.RowIndex < _bindingList.Count)
            {
                var item = _bindingList[e.RowIndex];

                // **CRITICAL:** Read the NEW Status value from the UI/BindingList
                bool newStatus = item.Status;

                try
                {
                    // Persist change to the database
                    var options = new DbContextOptionsBuilder<InventoryContext>()
                        .UseSqlite(_connectionString)
                        .Options;

                    using var ctx = new InventoryContext(options);

                    // 3. Find the entity in the database
                    var entity = await ctx.TaskNotes.FindAsync(item.TasknotesID);

                    if (entity != null)
                    {
                        // 4. Update the entity with the NEW Status value
                        entity.Status = newStatus;
                        await ctx.SaveChangesAsync();

                        // Optional: Provide UI feedback for success
                        // Console.WriteLine($"Task {item.TasknotesID} updated to Status: {newStatus}");
                    }
                    else
                    {
                        // Handle case where entity was deleted elsewhere
                        await LoadTasksAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update task status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Reload the tasks to revert the UI checkbox to the saved state
                    await LoadTasksAsync();
                }
            }
        }

        private void TasksControl_Load(object sender, EventArgs e)
        {
            LoadTasksAsync();
        }

        public async Task LoadTasksAsync()
        {
            try
            {
                var options = new DbContextOptionsBuilder<InventoryContext>()
                    .UseSqlite(_connectionString)
                    .Options;

                using var ctx = new InventoryContext(options);
                var list = await ctx.TaskNotes.OrderBy(t => t.TasknotesID).ToListAsync();
                _bindingList = new BindingList<TaskNotes>(list);
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        _grid.DataSource = _bindingList;
                        LockDownGridColumns();
                    }));
                }
                else
                {
                    _grid.DataSource = _bindingList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneBtnAddTask_Click(object sender, EventArgs e)
        {
            TasksListForm tasksListForm = new TasksListForm();
            tasksListForm.TasksControlRef = this;
            tasksListForm.ShowDialog();
        }

        public async Task refreshTasksList()
        {
            await LoadTasksAsync();
            OnTasksChanged();
        }

        private void LockDownGridColumns()
        {
            // Loop through all automatically generated columns
            foreach (DataGridViewColumn column in _grid.Columns)
            {
                // By default, set every column to read-only
                column.ReadOnly = true;

                // Exempt the Status column and any other ID/Key columns you need to hide
                if (column.DataPropertyName == "Status")
                {
                    column.ReadOnly = false; // Allow editing (checking/unchecking)
                }
                else if (column.DataPropertyName == "TasknotesID")
                {
                    // You should hide the ID column but keep it read-only
                    column.Visible = false;
                }
                // Add more 'else if' conditions here for any other editable columns
            }
        }

        private async void siticoneBtnDeleteTask_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewTasks.GridView.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more tasks to delete.", "Delete Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected task(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    if (rowIndex < 0 || rowIndex >= siticoneDataGridViewTasks.GridView.Rows.Count) continue;
                    var row = siticoneDataGridViewTasks.GridView.Rows[rowIndex];

                    if (row.DataBoundItem is TaskNotes t)
                    {
                        idsToDelete.Add(t.TasknotesID);
                        continue;
                    }

                    // fallback: try to find a ProductsID cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                            (string.Equals(cell.OwningColumn.Name, "TasknotesID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.HeaderText, "TasknotesID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.Name, "ID", StringComparison.OrdinalIgnoreCase)))
                        {
                            idsToDelete.Add(parsed);
                            break;
                        }
                    }
                }

                if (idsToDelete.Count == 0)
                {
                    MessageBox.Show("Could not determine TasknotesID for selected rows.", "Delete Task", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var id in idsToDelete.Distinct())
                {
                    var entity = await _context.TaskNotes.FindAsync(id);
                    if (entity != null)
                        _context.TaskNotes.Remove(entity);
                }

                await _context.SaveChangesAsync();
                // reload and notify
                await refreshTasksList();

                MessageBox.Show("Selected task(s) deleted.", "Delete Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting tasks: " + ex.Message, "Delete Task", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
