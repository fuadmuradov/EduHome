using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Course
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Apply { get; set; }
        public string Certification { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<CourseFeature> CourseFeatures { get; set; }
        public List<Compaign> Compaigns { get; set; }
    }
}
