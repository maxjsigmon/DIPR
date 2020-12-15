using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Sleep
{
   public class SleepListItem
    {
        [Key]
        public int SleepID { get; set; }

        public Location Location { get; set; }

        [Display(Name = "Sleep Starting Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]DataFormatString = "0:H: mm tt")]
        public DateTime SleepStart { get; set; }

        [Display(Name = "Sleep End Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepEnd { get; set; }

        [Display(Name = "Total Time Slept")]
        public TimeSpan TotalSleep { get => SleepEnd - SleepStart; }
        public string Name { get; set; }
        public string Notes { get; set; }

    }
}
