using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Sleep
{
   public class SleepEdit
    {
        public int SleepID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Sleeping Location")]
        public Location Location { get; set; }

        [Display(Name = "Sleep Starting Time")]
        public DateTime SleepStart { get; set; }

        [Display(Name = "Sleep End Time")]
        public DateTime SleepEnd { get; set; }
        public string Notes { get; set; }
        public SelectList Babies { get; set; }
    }
}
