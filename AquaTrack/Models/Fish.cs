using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    internal class Fish : Products
    {
        public int FishID { get; set; }
        public int ProductID { get; set; } // Foreign key to Products
        public string Species { get; set; }
        public string WaterType { get; set; } // e.g., Freshwater, Saltwater
        public string Size { get; set; } // e.g., Small, Medium, Large
        public int Age { get; set; } // in months
    }
}
