using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Data
{
    public class Diaper
    {
        [Key]
        public int DiaperID { get; set; }

        [Required]
        public Soiled Soiled { get; set; }
        public string Notes { get; set; }
    }

    public enum Soiled
    {
        Wet,
        Dirty,
        Both
    }
}
