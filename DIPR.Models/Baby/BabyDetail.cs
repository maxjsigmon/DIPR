using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Baby
{
    public class BabyDetail
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Gender:")]
        public Gender Gender { get; set; }

        [Display(Name = "Birth Date:")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }
    }
}
