using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Baby
{
    public class BabyEdit
    {
        public int BabyID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Gender")]
        public Gender Gender { get; set; }
        public string Notes { get; set; }
        
    }
}
