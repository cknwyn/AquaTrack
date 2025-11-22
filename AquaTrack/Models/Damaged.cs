using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    internal class Damaged
    {
        public int DamageID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateReported { get; set; }
        public string Description { get; set; }
        public Products Product { get; set; }
    }
}
