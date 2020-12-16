using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Diaper
{
    public class DiaperEdit
    {
        public int DiaperID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Correct Soil Type")]
        public Soiled Soiled { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
    }
}
