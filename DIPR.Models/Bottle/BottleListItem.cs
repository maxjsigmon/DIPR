using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Bottle
{
    public class BottleListItem
    {
        [Key]
        [Display(Name = "Bottle ID #")]
        public int BottleID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Contents Contents { get; set; }

        [Display(Name = "Quantity (Oz.)")]
        public decimal Quantity { get; set; }

        [Display(Name = "Consumed (Oz.)")]
        public decimal Consumed { get; set; }
        public string Notes { get; set; }

    }
}
