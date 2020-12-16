using System;
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
        public Guid ParentID { get; set; }

        [Required]
        public decimal TimeFed { get; set; }

        [Required]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }

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
