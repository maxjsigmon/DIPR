using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Baby
{
    public class BabyEdit
    {
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Birth Date:")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender:")]
        public Gender Gender { get; set; }

        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        [Display(Name = "Notes:")]
        public string Notes { get; set; }

    }
}
