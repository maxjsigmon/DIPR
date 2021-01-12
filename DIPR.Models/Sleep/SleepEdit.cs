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
   public class SleepEdit
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name="Sleep ID #:")]
        public int SleepID { get; set; }

        [Display(Name = "Location:")]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Sleeping Location")]
        public Location Location { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        [Display(Name = "Sleep Starting Time:")]
        public DateTime SleepStart { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        [Display(Name = "Sleep End Time:")]
        public DateTime SleepEnd { get; set; }

        [Display(Name ="Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }

        [Display(Name ="Baby:")]
        public SelectList Babies { get; set; }
    }
}
