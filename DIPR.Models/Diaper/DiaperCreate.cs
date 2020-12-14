using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Diaper
{
    public class DiaperCreate
    {
        public DiaperCreate()
        {
            SoiledList = GetSoiledSelectList();
        }

        public SelectList SoiledList { get; set; }
        public Soiled Soiled { get; set; }
        public static SelectList GetSoiledSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Soiled)).Cast<Soiled>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
