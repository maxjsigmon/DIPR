using DIPR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Nursing
{
   public class NursingEdit
    {
        public int NursingID { get; set; }
        public decimal TimeFed { get; set; }
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
    }
}
