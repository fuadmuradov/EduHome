﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Compaign
    {
        public int id { get; set; }
        [Required]
        public int DiscountPercent { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
