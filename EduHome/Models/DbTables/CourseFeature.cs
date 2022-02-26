using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class CourseFeature
    {
        public int id { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int ClassDuration { get; set; }
        public string SkilLevel { get; set; }
        public string Language { get; set; }
        public int StudentCount { get; set; }
        public string Assesment { get; set; }
        public double Price { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
