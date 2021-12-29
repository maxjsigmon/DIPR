using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPR.Data
{
    public class BottleFeeding
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid ParentID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Consumed { get; set; }

        [Required]
        public Contents Contents { get; set; }
        public string Notes { get; set; }

        public string Name { get; set; }

        public int BabyID { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }

    }

    public enum Contents
    {
        [Display(Name = "Breast Milk")]
        BreastMilk = 1,
        Formula = 2,
        Milk = 3,
        Water = 4
    }
}
