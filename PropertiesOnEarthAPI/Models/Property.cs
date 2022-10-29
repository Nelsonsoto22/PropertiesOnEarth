using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesOnEarthAPI.Models
{
    public class Property
    {
         public int Id { get; set; }

        [Required(ErrorMessage = "Property Name most be provided")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Property Detail most be provided")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Property Address most be provided")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Property ImageUrl most be provided")]
        [MaxLength(250)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Property Price most be provided")]
        public double Price { get; set; }

        public bool IsTrending { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        public int UserId { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }  
    }
}