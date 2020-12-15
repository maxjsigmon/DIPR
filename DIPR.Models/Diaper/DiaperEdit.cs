using DIPR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Diaper
{
    public class DiaperEdit
    {
        public int DiaperID { get; set; }
        public Soiled Soiled { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
    }
}
