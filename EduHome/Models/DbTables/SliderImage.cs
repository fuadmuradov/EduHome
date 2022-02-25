using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class SliderImage
    {
        public int id { get; set; }

        public string Image { get; set; }

        public int SliderId { get; set; }

        public Slider Slider { get; set; }


    }
}
