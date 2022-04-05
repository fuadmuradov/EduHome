using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Course
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 5000)]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 5000)]
        public string About { get; set; }
        [Required]
        [StringLength(maximumLength: 5000)]
        public string Apply { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Certification { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<CourseFeature> CourseFeatures { get; set; }
        public List<Compaign> Compaigns { get; set; }
    }
}
