using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Nursing
{
   public class NursingEdit
    {
        public int NursingID { get; set; }
        public decimal TimeFed { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Feeding Side")]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
    }
}
