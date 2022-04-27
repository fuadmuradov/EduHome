using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Testimional
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Fullname { get; set; }
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Responsibility { get; set; }
        [Required]
        [StringLength(maximumLength: 1200)]
        public string Description { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
