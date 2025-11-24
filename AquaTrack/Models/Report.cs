using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class Report
    {
        public int ReportID { get; set; } 
        public DateTime ReportDate { get; set; } 
        public string ReportType { get; set; } // e.g., Sales, Inventory, Damaged Goods
        public string ReportTitle { get; set; } // e.g., "Monthly Sales Report"
        public string Total { get; set; } // e.g., Total Sales Amount, Total Damaged Items
    }
}
