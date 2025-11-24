using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class Products
    {
        public int ProductsID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }
        public int SupplierID { get; set; } // Foreign key to Supplier
    }
}
