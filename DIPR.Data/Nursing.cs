﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
   public class Nursing
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan TimeFeeding { get; set; }

        [Required]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }

        [Required]
        public int BabyID { get; set; }

        [ForeignKey(nameof(BabyID))]
        public virtual Baby Baby { get; set; }
    }

    public enum FeedingSide
    {
        Left,
        Right
    }
}
