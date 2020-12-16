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
    public class NursingCreate
    {
        
        public int BabyID { get; set; }

        [Required]
        [Display(Name = "Time Spent Feeding (Minutes)")]
        public decimal TimeFed { get; set; }

        [Required]
        public FeedingSide FeedingSide { get; set; }

        public string Notes { get; set; }

        public NursingCreate()
        {
            FeedingSideList = GetFeedingSideSelectList();
        }

        public SelectList FeedingSideList { get; set; }

        public static SelectList GetFeedingSideSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Contents)).Cast<Contents>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
