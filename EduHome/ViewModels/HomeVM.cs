using EduHome.Models.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public Slider Slider { get; set; }
        public List<Notice> Notices { get; set; }
        public List<NoticeSecond> NoticeSeconds { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }

    }
}
