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
    public partial class CustomersControl : UserControl
    {
        private InventoryContext _context;
        public CustomersControl()
        {
            InitializeComponent();
        }

        private void siticoneBtnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.CustomerControlRef = this;
            customersForm.ShowDialog();
        }

        private void CustomersControl_Load(object sender, EventArgs e)
        {
            loadCustomersAsync();
        }

        public async Task refreshCustomersList()
        {
            await loadCustomersAsync();
        }

        public async Task loadCustomersAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;
            _context = new InventoryContext(options);

            var customersList = await _context.Customers.OrderBy(c => c.CustomerID).ToListAsync();
            siticoneDataGridViewCustomers.DataSource = customersList;
            siticoneDataGridViewCustomers.Refresh();
        }

        private async void siticoneBtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var selectedRowIndexes = siticoneDataGridViewCustomers.GridView.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .ToList();

            if (selectedRowIndexes.Count == 0)
            {
                MessageBox.Show("Please select one or more customers to delete.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedRowIndexes.Count} selected customers(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    if (rowIndex < 0 || rowIndex >= siticoneDataGridViewCustomers.GridView.Rows.Count) continue;
                    var row = siticoneDataGridViewCustomers.GridView.Rows[rowIndex];

                    if (row.DataBoundItem is Customer c)
                    {
                        idsToDelete.Add(c.CustomerID);
                        continue;
                    }

                    // fallback: try to find a ProductsID cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out var parsed) &&
                            (string.Equals(cell.OwningColumn.Name, "CustomerID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.HeaderText, "CustomerID", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(cell.OwningColumn.Name, "ID", StringComparison.OrdinalIgnoreCase)))
                        {
                            idsToDelete.Add(parsed);
                            break;
                        }
                    }
                }

                if (idsToDelete.Count == 0)
                {
                    MessageBox.Show("Could not determine CustomerID for selected rows.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var id in idsToDelete.Distinct())
                {
                    var entity = await _context.Customers.FindAsync(id);
                    if (entity != null)
                        _context.Customers.Remove(entity);
                }

                await _context.SaveChangesAsync();

                // reload and notify
                await refreshCustomersList();

                MessageBox.Show("Selected customer(s) deleted.", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Delete customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
