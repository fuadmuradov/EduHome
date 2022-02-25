using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class TeacherHobby
    {
        public int id { get; set; }
        public int TeacherId { get; set; }
        public int HobbyId { get; set; }
        public Teacher Teacher { get; set; }
        public Hobby Hobby { get; set; }
    }
}
