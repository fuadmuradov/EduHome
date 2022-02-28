using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        [Required]
        public string BlogImage { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
