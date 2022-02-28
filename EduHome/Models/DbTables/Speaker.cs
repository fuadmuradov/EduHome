using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Speaker
    {
        public int id { get; set; }
        public string Fullname { get; set; }
        public string İmage { get; set; }
        public string Responsibility { get; set; }

        public List<EventSpeaker> EventSpeakers { get; set; }

    }
}
