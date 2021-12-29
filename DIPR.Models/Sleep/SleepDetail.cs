using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Sleep
{
    public class SleepDetail
    {
        [Display(Name = "Sleep ID #:")]
        public int SleepID { get; set; }

        [Display(Name = "Location:")]
        public Location Location { get; set; }

        [Display(Name = "Sleep Starting Time:")]
        public DateTime SleepStart { get; set; }

        [Display(Name = "Sleep End Time:")]
        public DateTime SleepEnd { get; set; }

        [Display(Name = "Total Time Slept:")]
        public TimeSpan TotalSleep { get => SleepEnd - SleepStart; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        public int BabyID { get; set; }
    }
}
