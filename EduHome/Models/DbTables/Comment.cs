using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Comment
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Subject { get; set; }
        [StringLength(maximumLength:1000)]
        public string Message { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
