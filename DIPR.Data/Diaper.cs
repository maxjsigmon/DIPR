﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPR.Data
{
    public class Diaper
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid ParentID { get; set; }

        [Required]
        public Soiled Soiled { get; set; }

        [Required]
        public DateTime Time { get; set; }
        public string Notes { get; set; }

        [Required]
        public int BabyID { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }

        //[ForeignKey(nameof(Baby))]
        //public int BabyId { get; set; }

    }
    public enum Soiled
    {
        Wet = 1,
        Dirty = 2,
        Both = 3
    }
}
