using AquaTrack.Data;
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
            LoadDncItems();
        }

        private async Task LoadDncItems()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;
            using (_context = new InventoryContext(options))
            {
                var dncItems = await Task.Run(() => _context.DamagedItems
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
        }

        public async Task RefreshDncItems()
        {
            await LoadDncItems();
        }
    }
}
