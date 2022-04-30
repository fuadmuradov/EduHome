using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.DbTables
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "you should be use a Correct Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Subject { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Message { get; set; }
    }
}
