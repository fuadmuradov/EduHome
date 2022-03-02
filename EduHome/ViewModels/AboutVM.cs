using EduHome.Models.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class AboutVM
    {
        public About About { get; set; }
        public Testimional Testimional { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
