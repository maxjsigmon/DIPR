using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
   public class Nursing
    {
        [Key]
        public int NursingID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan TimeFeeding { get; set; }

        [Required]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
    }

    public enum FeedingSide
    {
        Left,
        Right
    }
}
