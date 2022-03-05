using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class SliderImage
    {
        public int id { get; set; }

        public string Image { get; set; }
        [NotMapped]    
        public IFormFile Photo { get; set; }

        [Required]
        public int LineOrdeer { get; set; }
        [Required]
        public int SliderId { get; set; }

        public Slider Slider { get; set; }


    }
}
