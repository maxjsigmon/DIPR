using DIPR.Models.Diaper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Baby
{
    public class BabyDetail
    {
        public int BabyId { get; set; }
        public string Name { get; set; }

        public List<DiaperListItem> ListOfDiapers { get; set; } = new List<DiaperListItem>();

    }
}
