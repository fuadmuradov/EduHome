using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class NoticeSecond
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength:70)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string Description { get; set; }



    }
}
