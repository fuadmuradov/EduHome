﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Slider
    {
        public int id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<SliderImage> SliderImages { get; set; }

    }
}
