using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerID { get; set; }
        public string PaymentMethod { get; set; }
        public List<SaleItem> SaleItems { get; set; }
    }
}
