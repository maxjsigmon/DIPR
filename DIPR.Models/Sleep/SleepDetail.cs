using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Sleep
{
   public class SleepDetail
    {
        public int SleepID { get; set; }
        public TimeSpan TotalSleep { get; set; }
    }
}
