using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class CourseFeature
    {
        public int id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ClassDuration { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string SkilLevel { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Language { get; set; }
        [Required]
        public int StudentCount { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Assesment { get; set; }
        [Required]
        public double Price { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
