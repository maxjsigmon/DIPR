using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DIPR.Models.Bottle
{
    public class BottleEdit
    {

        public int BabyID { get; set; }

        [Display(Name = "Bottle ID #:")]
        public int BottleID { get; set; }

        [Display(Name = "Time:")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime Time { get; set; }

        [Display(Name = "Quantity (Oz.):")]
        public decimal Quantity { get; set; }

        [Display(Name = "Consumed (Oz.):")]
        public decimal Consumed { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Correct Content Type")]
        [Display(Name = "Contents:")]
        public Contents Contents { get; set; }

        [Display(Name = "Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }

        [Display(Name = "Baby:")]
        public SelectList Babies { get; set; }
    }
}
