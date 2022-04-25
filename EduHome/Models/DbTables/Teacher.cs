using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Teacher
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Image { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Job { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Experience { get; set; }

        public List<TeacherHobby> TeacherHobbies { get; set; }
        public List<TeacherFaculty> TeacherFaculties { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}
