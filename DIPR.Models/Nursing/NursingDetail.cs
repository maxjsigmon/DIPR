using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Nursing
{
    public class NursingDetail
    {
        public int BabyID { get; set; }

        [Display(Name = "Nursing ID #:")]
        public int NursingID { get; set; }

        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Time Spent Feeding:")]
        public decimal TimeFed { get; set; }

        [Display(Name = "Left or Right Side:")]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
    }
}
