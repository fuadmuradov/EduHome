using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Speaker
    {
        public int id { get; set; }
        [Required]
        public string Fullname { get; set; }
        public string İmage { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string Responsibility { get; set; }

        public List<EventSpeaker> EventSpeakers { get; set; }

    }
}
