using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}
