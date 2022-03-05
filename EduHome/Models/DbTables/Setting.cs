using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Setting
    {
        public int id { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string Mail { get; set; }
        public string WebSite { get; set; }

    }
}
