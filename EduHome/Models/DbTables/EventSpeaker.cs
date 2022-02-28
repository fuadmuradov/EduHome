using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class EventSpeaker
    {
        public int id { get; set; }
      
        public int Eventid { get; set; }
        public int Speakerid { get; set; }

        public Event Event { get; set; }
        public Speaker Speaker { get; set; }
    }
}
