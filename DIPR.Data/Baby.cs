
using System;
using System.ComponentModel.DataAnnotations;

namespace DIPR.Data
{

    public class Baby
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid ParentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; }

        //public virtual Diaper Diaper { get; set; }
        //public virtual BottleFeeding BottleFeeding { get; set; }
        //public virtual Nursing Nursing { get; set; }
        //public virtual Sleep Sleep { get; set; }
    }

    public enum Gender
    {
        Boy = 1,
        Girl = 2
    }
}
