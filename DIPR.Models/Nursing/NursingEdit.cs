using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Nursing
{
   public class NursingEdit
    {
        [Display(Name ="Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name = "Nursing ID #:")]
        public int NursingID { get; set; }

        [Display(Name = "Time Spent Feeding:")]
        public decimal TimeFed { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Feeding Side")]
        [Display(Name = "Left or Right Side:")]
        public FeedingSide FeedingSide { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        [Display(Name = "Baby:")]
        public SelectList Babies { get; set; }

        public string Name { get; set; }

    }
}
