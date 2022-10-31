using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesOnEarthAPI.Models
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "User Email most be provided")]
        [MaxLength(50)]
        [MinLength(3)]
        [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Valid Email Address must be provided")]
        public string Email { get; set; }

        [Column("PasswordHash")]
        [Required(ErrorMessage = "User PasswordHash most be provided")]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}