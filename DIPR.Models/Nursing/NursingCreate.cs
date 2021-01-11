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
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        [Display(Name ="Time:")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Time Spent Feeding (Minutes):")]
        public decimal TimeFed { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Feeding Side")]
        [Display(Name = "Feeding Side:")]
        public FeedingSide FeedingSide { get; set; }

        [Display(Name = "Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }

        //public NursingCreate()
        //{
        //    FeedingSideList = GetFeedingSideSelectList();
        //}

        public SelectList FeedingSideList { get; set; }

        //public static SelectList GetFeedingSideSelectList()
        //{
        //    var enumValues = Enum.GetValues(typeof(Contents)).Cast<Contents>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
        //    return new SelectList(enumValues, "Value", "Text", "");
        //}
    }
}
