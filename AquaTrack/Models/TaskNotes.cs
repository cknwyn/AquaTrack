using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Models
{
    public class TaskNotes
    {
        public int TasknotesID { get; set; }
        public DateTime? Deadline { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
