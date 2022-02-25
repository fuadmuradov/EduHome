using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Contact
    {
        public int id { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public string SkypeName { get; set; }
        public string SkypeUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string TwitterUrl { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
