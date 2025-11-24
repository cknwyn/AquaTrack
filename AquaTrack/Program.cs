using Microsoft.EntityFrameworkCore;
using AquaTrack.Data;

namespace AquaTrack
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var optionBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionBuilder.UseSqlite("Data Source=InventoryAndSales.db");
            InventoryContext context = new InventoryContext(optionBuilder.Options);
            context.Database.EnsureCreated();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(context));
        }
    }
}