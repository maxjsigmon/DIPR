using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
    public class BottleFeeding
    {
        [Key]
        public int BottleFeedingID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Consumed { get; set; }

        [Required]
        public Contents Contents { get; set; }
        public string Notes { get; set; }
    }

    public enum Contents
    {
        BreastMilk,
        Formula,
        Milk,
        Water
    }
}
