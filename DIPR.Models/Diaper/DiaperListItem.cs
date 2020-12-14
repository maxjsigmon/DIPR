using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Diaper
{
    public class DiaperListItem
    {
        public Soiled Soiled { get; set; }
    }

    public enum Soiled
    {
        Wet,
        Dirty,
        Both
    }
}
