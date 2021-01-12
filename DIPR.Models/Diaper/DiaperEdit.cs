using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Diaper
{
    public class DiaperEdit
    {
        public int BabyID { get; set; }

        [Display(Name = "Diaper ID #:")]
        public int DiaperID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Correct Soil Type")]
        [Display(Name = "Soil Type:")]
        public Soiled Soiled { get; set; }

        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Display(Name = "Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }

        [Display(Name = "Baby:")]
        public SelectList Babies { get; set; }
    }
}
