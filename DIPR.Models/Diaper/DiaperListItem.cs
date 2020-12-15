using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Diaper
{
    public class DiaperListItem
    {
        [Key]
        public int BabyID { get; set; }
        public int DiaperID { get; set; }
        public DateTime Time { get; set; }
        public Soiled Soiled { get; set; }
        public string Notes { get; set; }

        //public List<DiaperListItem> TotalDiapers = new List<DiaperListItem>();
    }

    //public enum Soiled
    //{
    //    Wet,
    //    Dirty,
    //    Both
    //}
}
