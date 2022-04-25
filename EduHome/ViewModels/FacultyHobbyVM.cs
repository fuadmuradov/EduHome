using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    [NotMapped]
    public class FacultyHobbyVM
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public List<int> HobbyIds { get; set; }
        [Required]
        public List<int> FacultyIds { get; set; }

    }
}
