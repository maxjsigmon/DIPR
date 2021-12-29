using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Nursing
{
    public class NursingListItem
    {
        [Key]
        [Display(Name = "Nursing ID #")]
        public int NursingID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }

        [Display(Name = "Time Spent Feeding (Minutes)")]
        public decimal TimeFed { get; set; }

        [Display(Name = "Left or Right Side")]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
        public int BabyID { get; set; }

    }
}
