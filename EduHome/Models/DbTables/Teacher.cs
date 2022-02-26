using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Teacher
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
        public string About { get; set; }
        public string Degree { get; set; }
        public int Experience { get; set; }

        public List<TeacherHobby> TeacherHobbies { get; set; }
        public List<TeacherFaculty> TeacherFaculties { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}
