using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
    
    public class Baby
    {
        [Key]
        public int BabyID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; }
    }

    public enum Gender
    {
        Boy,
        Girl
    }
}
