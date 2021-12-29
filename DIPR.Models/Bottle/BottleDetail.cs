using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Bottle
{
    public class BottleDetail
    {
        [Display(Name = "Bottle ID #:")]
        public int BottleID { get; set; }

        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Display(Name = "Contents:")]
        public Contents Contents { get; set; }

        [Display(Name = "Quantity:")]
        public decimal Quantity { get; set; }

        [Display(Name = "Consumed:")]
        public decimal Consumed { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        public int BabyID { get; set; }

    }
}
