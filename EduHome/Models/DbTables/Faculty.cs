using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Faculty
    {
        public int id { get; set; }
        public string Name { get; set; }

        public List<TeacherFaculty> TeacherFaculties { get; set; }
    }
}
