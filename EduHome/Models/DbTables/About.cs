using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class About
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
