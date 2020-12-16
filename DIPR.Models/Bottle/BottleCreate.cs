using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models.Bottle
{
   public class BottleCreate
    {
        [Key]
        public int BabyID { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Consumed { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Select a Content Type")]
        public Contents Contents { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }

        public BottleCreate()
        {
            ContentsList = GetContentsSelectList();
        }

        public SelectList ContentsList { get; set; }

        public static SelectList GetContentsSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Contents)).Cast<Contents>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
