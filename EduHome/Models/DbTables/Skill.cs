using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Skill
    {
        public int id { get; set; }
        [Required]
        [Range(0, 100)]
        public int Language { get; set; }
        [Required]
        [Range(0, 100)]
        public int Leader { get; set; }
        [Required]
        [Range(0, 100)]
        public int Development { get; set; }
        [Required]
        [Range(0, 100)]
        public int Design { get; set; }
        [Required]
        [Range(0, 100)]
        public int Innovation { get; set; }
        [Required]
        [Range(0, 100)]
        public int Communication { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }



    }
}
