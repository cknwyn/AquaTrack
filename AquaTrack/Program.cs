using AquaTrack.Data;
using Microsoft.EntityFrameworkCore;
using PdfSharp;
using PdfSharp.Fonts;

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
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            var optionBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionBuilder.UseSqlite("Data Source=InventoryAndSales.db");
            InventoryContext context = new InventoryContext(optionBuilder.Options);
            context.Database.EnsureCreated();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(context));
        }
    }
}