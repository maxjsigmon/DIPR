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
        [Display(Name = "Baby ID #")]
        public int BabyID { get; set; }

        [Display(Name = "Diaper ID #")]
        public int DiaperID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }

        [Display(Name = "Soil Type")]
        public Soiled Soiled { get; set; }
        public string Notes { get; set; }

        //public List<DiaperListItem> TotalDiapers = new List<DiaperListItem>();
    }
}
