﻿using System;
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
        public Location Location { get; set; }
        [Required]
        public TimeSpan TimeSlept { get; set; }
        public string Notes { get; set; }

        public int BabyID { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }
    }

    public enum Location
    {
        Crib,
        Bed,
        Bassinet,
        CarSeat,
        Carrier,
        Stroller,
        Other
    }
}
