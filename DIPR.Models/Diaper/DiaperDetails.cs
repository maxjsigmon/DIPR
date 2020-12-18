using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Diaper
{
    public class DiaperDetails
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name = "Diaper ID #:")]
        public int DiaperID { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Display(Name = "Soil Type:")]
        public Soiled Soiled { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }
    }
}
