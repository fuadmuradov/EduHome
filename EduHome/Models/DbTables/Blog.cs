using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models.DbTables
{
    public class Blog
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Writer { get; set; }
        public string BlogImage { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
