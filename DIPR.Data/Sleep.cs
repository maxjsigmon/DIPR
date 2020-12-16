using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
   public class Sleep
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid ParentID { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [Display(Name ="Sleep Starting Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepStart { get; set; }

        [Required]
        [Display(Name ="Sleep End Time")]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm tt")]
        public DateTime SleepEnd { get; set; }

        [Display(Name ="Total Time Slept")]
        public TimeSpan TotalSleep { get => SleepEnd - SleepStart; }
        public string Notes { get; set; }

        public int BabyID { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }
    }

    public enum Location
    {
        Crib = 1,
        Bed,
        Bassinet,
        [Display(Name = "Car Seat")]
        CarSeat,
        Carrier,
        Stroller,
        Other
    }
}
