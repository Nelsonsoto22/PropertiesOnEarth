using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesOnEarthAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name most be provided")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Email most be provided")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Phone most be provided")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "User PasswordHash most be provided")]
        [MaxLength(50)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "User PasswordSalt most be provided")]
        [MaxLength(50)]
        public string PasswordSalt { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}