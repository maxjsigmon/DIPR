using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Doctor_Connect
{
    public class DoctorConnect
    {
        // Baby Properties
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string BabyNotes { get; set; }

        // Bottle Properties
        public DateTime BottleTime { get; set; }
        public Contents Contents { get; set; }
        public decimal Quantity { get; set; }
        public decimal Consumed { get; set; }
        public string BottleNotes { get; set; }

        // Diaper Properties
        public DateTime DiaperTime { get; set; }

        [Display(Name = "Soil Type")]
        public Soiled Soiled { get; set; }
        public string DiaperNotes { get; set; }

        //Nursing Properties
        [Display(Name = "Time Spent Feeding")]
        public decimal TimeFed { get; set; }

        [Display(Name = "Left or Right Side")]
        public FeedingSide FeedingSide { get; set; }
        public string NursingNotes { get; set; }

        //Sleep Properties
        public Location Location { get; set; }

        [Display(Name = "Sleep Starting Time")]
        public DateTime SleepStart { get; set; }

        [Display(Name = "Sleep End Time")]
        public DateTime SleepEnd { get; set; }

        [Display(Name = "Total Time Slept")]
        public TimeSpan TotalSleep { get => SleepEnd - SleepStart; }
        public string SleepNotes { get; set; }
    }
}
