using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class Fish : Products
    {
        public string Species { get; set; }
        public string WaterEnvironment { get; set; } // e.g., Freshwater, Saltwater
        public int Age { get; set; } // in months
    }
}
