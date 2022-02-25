using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class TeacherFaculty
    {
        public int id { get; set; }
        public int TeacherId { get; set; }
        public int FacultyId { get; set; }

        public Teacher Teacher { get; set; }
        public Faculty Faculty { get; set; }
    }
}
