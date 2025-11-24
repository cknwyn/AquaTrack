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
        private int _taskIdToEdit = 0;
        public TasksListForm() : this(0) { }
        public TasksListForm(int taskId)
        {
            InitializeComponent();
            _taskIdToEdit = taskId;

            if (_taskIdToEdit > 0)
            {
                this.Text = "Edit Existing Task";
                LoadTaskData(_taskIdToEdit);
            }
            else
            {
                this.Text = "Add New Task";
            }
        }
        private async void LoadTaskData(int taskId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            var options = optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db").Options;

            using (var context = new InventoryContext(options))
            {
                try
                {
                    var task = await context.TaskNotes.FindAsync(taskId);

                    if (task == null)
                    {
                        MessageBox.Show("Task not found.", "Error");
                        this.Close();
                        return;
                    }

                    // Populate fields
                    siticoneTextAreaTask.Text = task.Content;
                    siticoneDTPDeadline.Value = task.Deadline;

                    // Note: Status is handled via the DataGridView checkbox on the main control
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load task data: " + ex.Message, "Error");
                }
            }
        }

        private async void siticoneButtonTaskConfirm_Click(object sender, EventArgs e)
        {
            if (siticoneDTPDeadline.Value == null)
            {
                MessageBox.Show("Please select a valid deadline", "Error");
                return;
            }
            if (string.IsNullOrWhiteSpace(siticoneTextAreaTask.Text))
            {
                MessageBox.Show("Task content cannot be empty.", "Error");
                return;
            }

            string content = siticoneTextAreaTask.Text;
            DateTime deadline = siticoneDTPDeadline.Value.GetValueOrDefault(); // Use GetValueOrDefault for safety

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlite("Data Source=InventoryAndSales.db");

            try
            {
                using (var context = new InventoryContext(optionsBuilder.Options))
                {
                    Models.TaskNotes taskToSave;
                    string successMessage;

                    if (_taskIdToEdit > 0)
                    {
                        // === EDIT MODE ===
                        taskToSave = await context.TaskNotes.FindAsync(_taskIdToEdit);
                        if (taskToSave == null) throw new Exception("Task not found for update.");
                        successMessage = "updated";
                    }
                    else
                    {
                        // === ADD MODE ===
                        taskToSave = new Models.TaskNotes();
                        context.TaskNotes.Add(taskToSave);
                        successMessage = "added";
                    }

                    // update properties
                    taskToSave.Content = content;
                    taskToSave.Deadline = deadline;
                    
                    await context.SaveChangesAsync();

                    TasksControlRef?.refreshTasksList();
                    MessageBox.Show($"Task successfully {successMessage}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show(ex.InnerException?.Message ?? ex.Message); // Re-enable for debugging
            }
        }
    }
}
