﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPR.Data
{
    public class Nursing
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid ParentID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal TimeFed { get; set; }

        public string Name { get; set; }

        [Required]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }

        public int BabyID { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }
    }

    public enum FeedingSide
    {
        Left = 1,
        Right = 2
    }
}
