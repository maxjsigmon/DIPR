using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Sleep
{
    public class SleepCreate
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Sleeping Location")]
        [Display(Name = "Location:")]
        public Location Location { get; set; }

        [Required]
        [Display(Name = "Sleep Starting Time:")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepStart { get; set; }

        [Required]
        [Display(Name = "Sleep End Time:")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepEnd { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        public SleepCreate()
        {
            LocationList = GetLocationSelectList();
        }

        public SelectList LocationList { get; set; }

        public static SelectList GetLocationSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Location)).Cast<Location>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
