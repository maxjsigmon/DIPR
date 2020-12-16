using DIPR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Bottle
{
    public class BottleEdit
    {
        public int BottleID { get; set; }
        public DateTime Time { get; set; }
        public decimal Quantity { get; set; }
        public decimal Consumed { get; set; }
        public Contents Contents { get; set; }
        public string Notes { get; set; }
    }
}
