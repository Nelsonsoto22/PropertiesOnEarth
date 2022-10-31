using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PropertiesOnEarthAPI.Models
{
    public class User : UserCredentials
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name most be provided")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Phone most be provided")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string? PasswordSalt { get; set; }

        public ICollection<Property>? Properties { get; set; }
    }
}