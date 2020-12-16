using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Bottle
{
    public class BottleListItem
    {
        [Key]
        public int BabyID { get; set; }
        public int BottleID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Contents Contents { get; set; }
        public decimal Quantity { get; set; }
        public decimal Consumed { get; set; }
        public string Notes { get; set; }

    }
}
