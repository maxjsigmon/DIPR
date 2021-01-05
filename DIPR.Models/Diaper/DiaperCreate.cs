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
        [Display(Name = "Baby ID #:")]
        public int BabyID { get; set; }

        //[Display(Name = "Name:")]
        //public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:H:mm")]
        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Correct Soil Type")]
        [Display(Name="Soil Type:")]
        public Soiled Soiled { get; set; }

        [Display(Name = "Notes:")]
        [MaxLength(100, ErrorMessage = "Limit notes to 100 characters.")]
        public string Notes { get; set; }
        public DiaperCreate()
        {
            SoiledList = GetSoiledSelectList();
        }

        public SelectList SoiledList { get; set; }
        
        public static SelectList GetSoiledSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Soiled)).Cast<Soiled>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }
}
