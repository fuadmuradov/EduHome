using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Event
    {
        public int id { get; set; }
        public int Day { get; set; }
        public string Month { get; set; }
        public string İmage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }

    }
}
