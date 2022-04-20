using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Event
    {
        public int id { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public string Month { get; set; }
        public string İmage { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }

    }
}
