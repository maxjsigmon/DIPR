using DIPR.Data;
using DIPR.Models.Baby;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DIPR.Models
{
    public class BabyCreate
    {
        [Required]
        [MaxLength(15, ErrorMessage = "There are too many characters. Please, consider changing the baby's name.")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Gender")]
        [Display(Name = "Gender:")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name ="Birth Date:")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        public BabyCreate()
        {
            GenderList = GetGenderSelectList();
        }

        public SelectList GenderList { get; set; }

        public static SelectList GetGenderSelectList()
        {
            var enumValues = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            return new SelectList(enumValues, "Value", "Text", "");
        }
    }

}
