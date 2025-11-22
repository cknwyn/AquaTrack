using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    internal class Equipment : Products
    {
        public string EquipmentType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

    }
}
