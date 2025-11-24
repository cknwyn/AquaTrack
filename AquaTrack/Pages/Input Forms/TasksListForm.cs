using AquaTrack.Data;
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

namespace AquaTrack.Pages.Input_Forms
{
    public partial class TasksListForm : Form
    {
        private InventoryContext _context;
        public TasksControl TasksControlRef { get; set; }
        public TasksListForm()
        {
            InitializeComponent();
        }

        private void siticoneButtonTaskConfirm_Click(object sender, EventArgs e)
        {
            if (siticoneDTPDeadline.Value == null)
            {
                MessageBox.Show("Please select a valid deadline", "Error");
                return;
            }

            string content = siticoneTextAreaTask.Text;
            DateTime date = (DateTime)siticoneDTPDeadline.Value;

            using (var context = new Data.InventoryContext(
                new DbContextOptionsBuilder<Data.InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options))
            {
                var newTask = new Models.TaskNotes
                {
                    Content = siticoneTextAreaTask.Text,
                    Deadline = (DateTime)siticoneDTPDeadline.Value,
                    Status = false
                };
                context.TaskNotes.Add(newTask);
                try
                {
                    context.SaveChanges();

                    TasksControlRef?.refreshTasksList();
                    MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.InnerException?.Message);
                }
            }
        }
    }
}
