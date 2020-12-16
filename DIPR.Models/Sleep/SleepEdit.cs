using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Sleep
{
   public class SleepEdit
    {
        public int SleepID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Sleeping Location")]
        public Location Location { get; set; }

        [Display(Name = "Sleep Starting Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepStart { get; set; }

        [Display(Name = "Sleep End Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepEnd { get; set; }
        public string Notes { get; set; }
    }
}
