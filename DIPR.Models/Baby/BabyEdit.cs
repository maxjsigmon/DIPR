using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Baby
{
    public class BabyEdit
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Birth Date:")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender:")]
        public Gender Gender { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }
        
    }
}
