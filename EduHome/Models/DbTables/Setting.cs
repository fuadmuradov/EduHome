using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Setting
    {
        public int id { get; set; }
        public string Logo { get; set; }
        [Required]
        [StringLength(maximumLength:400)]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string phone1 { get; set; }
        [Required]
        public string phone2 { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string WebSite { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
