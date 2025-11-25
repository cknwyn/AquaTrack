using AquaTrack.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AquaTrack.Pages.Input_Forms
{
    public partial class ReportForm : Form
    {
        private List<string> _reportLines = new List<string>();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void siticoneButtonReportCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButtonExportReport_Click(object sender, EventArgs e)
        {
            // Ensure data has been generated
            if (siticoneDGVReportSummary.DataSource == null && _reportLines.Count == 0)
            {
                MessageBox.Show("Please generate a report first.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"{siticoneDropdownReportType.SelectedItem}_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. Create a new PDF document
                        PdfDocument document = new PdfDocument();
                        document.Info.Title = $"{siticoneDropdownReportType.SelectedItem} Report";

                        // 2. Create an empty page
                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont fontTitle = new XFont("Courier", 16, XFontStyleEx.Bold);
                        XFont fontHeader = new XFont("Courier", 10, XFontStyleEx.Bold);
                        XFont fontBody = new XFont("Courier", 9, XFontStyleEx.Regular);

                        double yPosition = 50; // Starting Y coordinate
                        double leftMargin = 40;
                        double lineSpacing = 15;

                        // 3. Draw Report Title and Summary Lines
                        gfx.DrawString(document.Info.Title, fontTitle, XBrushes.Black, leftMargin, yPosition);
                        yPosition += 30;

                        // Draw the textual summary lines (Totals, counts, etc.)
                        foreach (string line in _reportLines)
                        {
                            gfx.DrawString(line, fontBody, XBrushes.Black, leftMargin, yPosition);
                            yPosition += lineSpacing;
                        }

                        yPosition += 20; // Add space before table/grid data

                        // 4. Draw DataGridView Content
                        if (siticoneDGVReportSummary.DataSource != null)
                        {
                            DrawDataGridView(gfx, siticoneDGVReportSummary.GridView, ref yPosition, leftMargin, fontHeader, fontBody, lineSpacing, page.Width);
                        }

                        // 5. Save the document
                        document.Save(sfd.FileName);
                        MessageBox.Show($"Report successfully exported to PDF:\n{sfd.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void siticoneButtonReportGenerate_Click(object sender, EventArgs e)
        {
            // Reset previous report data
            _reportLines.Clear();
            siticoneDGVReportSummary.DataSource = null; // Clear previous data

            // 1. Validate Inputs
            string reportType = siticoneDropdownReportType.SelectedItem?.ToString();
            DateTime startDate = siticoneDateTimePickerReportStartDate.Value.GetValueOrDefault().Date;
            DateTime endDate;

            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a Report Type.", "Input Error");
                return;
            }
            if (siticoneMaterialRadioButtonDaily.Checked)
            {
                endDate = startDate.Date.AddDays(1).AddMinutes(-1);
            } else
            {
                endDate = siticoneDateTimePickerReportEndDate.Value.GetValueOrDefault().Date;
                endDate = endDate.AddDays(1).AddSeconds(-1);
            }
            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date.", "Input Error");
                return;
            }

            // Query Data and Generate Report Structure
            var reportData = await GenerateReportDataAsync(reportType, startDate, endDate);

            if (reportData.StructuredData != null)
            {
                siticoneDGVReportSummary.DataSource = reportData.StructuredData;
            }
        }
        private class ReportResult
        {
            public object StructuredData { get; set; }
            public List<string> SummaryLines { get; set; } = new List<string>();
        }

        private async Task<ReportResult> GenerateReportDataAsync(string reportType, DateTime startDate, DateTime endDate)
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite("Data Source=InventoryAndSales.db")
                .Options;

            var result = new ReportResult();

            using (var ctx = new InventoryContext(options))
            {
                result.SummaryLines.Add($"--- {reportType.ToUpper()} REPORT: {startDate.ToShortDateString()} to {endDate.ToShortDateString()} ---");
                result.SummaryLines.Add(new string('-', 50));

                try
                {
                    switch (reportType)
                    {
                        case "Sales":
                            result.StructuredData = await GetSalesReportDataAsync(ctx, startDate, endDate, result.SummaryLines);
                            break;
                        case "Product":
                            result.StructuredData = await GetProductReportDataAsync(ctx, result.SummaryLines);
                            break;
                        case "Damage and Casualties":
                            result.StructuredData = await GetDamagedReportDataAsync(ctx, startDate, endDate, result.SummaryLines);
                            break;
                        default:
                            result.SummaryLines.Add("Invalid Report Type selected.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result.SummaryLines.Add($"An error occurred during report generation: {ex.Message}");
                }
            }
            return result;
        }

        private async Task<object> GetSalesReportDataAsync(InventoryContext ctx, DateTime startDate, DateTime endDate, List<string> summaryLines)
        {
            var sales = await ctx.Sales
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .ToListAsync();

            decimal grandTotal = sales.Sum(s => s.TotalAmount);

            summaryLines.Add($"Total Sales Records Found: {sales.Count}");
            summaryLines.Add($"GRAND TOTAL SALES: {grandTotal:C}");
            summaryLines.Add(new string('-', 50));

            // Project data to an anonymous type suitable for the grid, including the Customer Name
            var salesView = await (from s in ctx.Sales
                                   where s.SaleDate >= startDate && s.SaleDate <= endDate
                                   join c in ctx.Customers on s.CustomerID equals c.CustomerID into sc
                                   from customer in sc.DefaultIfEmpty()
                                   select new
                                   {
                                       SaleID = s.SaleID,
                                       Date = s.SaleDate.ToShortDateString(),
                                       CustomerName = customer.Name ?? "N/A",
                                       TotalAmount = s.TotalAmount,
                                       PaymentMethod = s.PaymentMethod
                                   }).ToListAsync();

            return salesView;
        }

        private async Task<object> GetDamagedReportDataAsync(InventoryContext ctx, DateTime startDate, DateTime endDate, List<string> summaryLines)
        {
            var damagedItems = await ctx.DamagedItems
                .Where(d => d.DateReported >= startDate && d.DateReported <= endDate)
                .ToListAsync();

            int totalQuantity = damagedItems.Sum(d => d.Quantity);

            summaryLines.Add($"Total Damaged Records Found: {damagedItems.Count}");
            summaryLines.Add($"TOTAL DAMAGED QUANTITY: {totalQuantity} units");
            summaryLines.Add(new string('-', 50));

            // Project data for the grid
            var damagedView = damagedItems.Select(d => new
            {
                d.DamagedID,
                d.DamagedName,
                d.Quantity,
                DateReported = d.DateReported.ToShortDateString()
            }).ToList();

            return damagedView;
        }

        private async Task<object> GetProductReportDataAsync(InventoryContext ctx, List<string> summaryLines)
        {
            var products = await ctx.Products
                .OrderBy(p => p.Name)
                .ToListAsync();

            decimal totalInventoryValue = products.Sum(p => p.Price * p.StockQuantity);

            summaryLines.Add($"Total Unique Products: {products.Count}");
            summaryLines.Add($"TOTAL INVENTORY VALUE (Price * Stock): {totalInventoryValue:C}");
            summaryLines.Add(new string('-', 50));

            // Project data for the grid
            var productView = products.Select(p => new
            {
                ProductID = p.ProductsID,
                p.Name,
                p.Category,
                p.Price,
                p.StockQuantity,
                TotalValue = p.Price * p.StockQuantity
            }).ToList();

            return productView;
        }

        private void siticoneMaterialRadioButtonDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneMaterialRadioButtonDaily.Checked)
            {
                siticoneMaterialRadioButtonMonthlyYearly.Checked = false;
                siticoneDateTimePickerReportStartDate.Enabled = true;

                siticoneDateTimePickerReportEndDate.Value = siticoneDateTimePickerReportStartDate.Value;
            }
            siticoneLabelEndDate.Enabled = false;
            siticoneDateTimePickerReportEndDate.Enabled = false;
        }

        private void siticoneMaterialRadioButtonMonthlyYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneMaterialRadioButtonMonthlyYearly.Checked)
            {
                siticoneMaterialRadioButtonDaily.Checked = false;
            }
            siticoneLabelEndDate.Enabled = true;
            siticoneDateTimePickerReportEndDate.Enabled = true;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            siticoneDateTimePickerReportStartDate.Enabled = false;
            siticoneDateTimePickerReportEndDate.Enabled = false;
        }

        private void DrawDataGridView(XGraphics gfx, DataGridView dgv, ref double yPosition, double xPosition, XFont fontHeader, XFont fontBody, double lineSpacing, XUnit pageWidth)
        {
            if (dgv.Rows.Count == 0 || dgv.Columns.Count == 0) return;

            // Calculate column widths (simple even split for demonstration)
            int visibleColumnCount = dgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
            if (visibleColumnCount == 0) return;

            double tableWidth = pageWidth.Point - (2 * xPosition);
            double columnWidth = tableWidth / visibleColumnCount;

            // 1. Draw Headers
            double xCurrent = xPosition;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    gfx.DrawString(col.HeaderText, fontHeader, XBrushes.Black, xCurrent, yPosition);
                    xCurrent += columnWidth;
                }
            }
            yPosition += lineSpacing;
            gfx.DrawLine(XPens.Black, xPosition, yPosition, xPosition + tableWidth, yPosition);
            yPosition += 5; // Space after header line

            // 2. Draw Rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                xCurrent = xPosition;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Visible)
                    {
                        string value = cell.Value?.ToString() ?? string.Empty;

                        // Handle potential page overflow for rows (very basic check)
                        if (yPosition > 750)
                        {
                            // Start a new page if necessary
                            PdfPage newPage = gfx.PdfPage.Owner.AddPage();
                            gfx = XGraphics.FromPdfPage(newPage);
                            yPosition = 50; // Reset Y position

                            // Redraw headers on new page (optional)
                            DrawColumnHeaders(gfx, dgv, ref yPosition, xPosition, fontHeader, columnWidth);
                        }

                        gfx.DrawString(value, fontBody, XBrushes.Black, xCurrent, yPosition);
                        xCurrent += columnWidth;
                    }
                }
                yPosition += lineSpacing;
            }
        }

        // Helper to redraw headers on new page (if implemented)
        private void DrawColumnHeaders(XGraphics gfx, DataGridView dgv, ref double yPosition, double xPosition, XFont fontHeader, double columnWidth)
        {
            double xCurrent = xPosition;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    gfx.DrawString(col.HeaderText, fontHeader, XBrushes.Black, xCurrent, yPosition);
                    xCurrent += columnWidth;
                }
            }
            yPosition += 20;
        }
    }
}
