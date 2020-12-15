using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Diaper
{
    public class DiaperCreate
    {
        public int BabyID { get; set; }

        public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm")]
        public DateTime Time { get; set; }
        public DiaperCreate()
        {
            SoiledList = GetSoiledSelectList();
        }

        public SelectList SoiledList { get; set; }

        [Required]
        public Soiled Soiled { get; set; }
        public string Notes { get; set; }
        public static SelectList GetSoiledSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Soiled)).Cast<Soiled>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
