using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class Damaged
    {
        public int DamagedID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string DamagedName { get; set; } = string.Empty;
        public DateTime DateReported { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
