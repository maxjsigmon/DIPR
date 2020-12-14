﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Models.Baby
{
   public class BabyListItem
    {
        [Key]
        public int BabyID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }

    public enum Gender
    {
        Boy,
        Girl
    }
}