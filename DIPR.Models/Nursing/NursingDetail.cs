﻿using DIPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Nursing
{
    public class NursingDetail
    {
        public int NursingID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Time Spent Feeding")]
        public decimal TimeFed { get; set; }

        [Display(Name = "Left or Right Side")]
        public FeedingSide FeedingSide { get; set; }
        public string Notes { get; set; }
    }
}
