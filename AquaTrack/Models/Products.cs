using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    internal class Products
    {
        public int ProductID { get; set; }
        public int DamageID { get; set; } // Foreign key to Damaged
        public int SaleItemID { get; set; } // Foreign key to SaleItem
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int SupplierID { get; set; } // Foreign key to Supplier

        public ICollection<SaleItem> SaleItems { get; set; }
        public ICollection<Damaged> DamageAndCasualties { get; set; }
        public Supplier Supplier { get; set; }
    }
}
