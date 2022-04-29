using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [StringLength(maximumLength: 70)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        [EmailAddress(ErrorMessage = "Write Correct Email Address!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
