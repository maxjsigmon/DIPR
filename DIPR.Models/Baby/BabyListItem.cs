using DIPR.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Models.Baby
{
    public class BabyListItem
    {
        [Key]
        [Display(Name = "Baby ID")]
        public int BabyID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; }
    }
}
