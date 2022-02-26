
using EduHome.Models.DbTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Compaign> Compaigns { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseFeature> CourseFeatures { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<NoticeSecond> NoticeSeconds { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherFaculty> TeacherFaculties { get; set; }
        public DbSet<TeacherHobby> TeacherHobbies { get; set; }


    }
}
