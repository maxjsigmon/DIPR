using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace DIPR.Models.Bottle
{
    public class BottleCreate
    {
        [Key]
        public int BabyID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Quantity (Oz.):")]
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "Consumed (Oz.):")]
        public decimal Consumed { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Content Type")]
        [Display(Name = "Contents:")]
        public Contents Contents { get; set; }

        [Display(Name = "Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }

        public string Name { get; set; }

        [Display(Name = "Baby:")]
        public SelectList Babies { get; set; }

        public BottleCreate()
        {
            ContentsList = GetContentsSelectList();
        }

        public SelectList ContentsList { get; set; }

        public static SelectList GetContentsSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Contents)).Cast<Contents>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
