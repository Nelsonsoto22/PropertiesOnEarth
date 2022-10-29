using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesOnEarthAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Category Name most be provided")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="ImageUrl most be provided")]
        [MaxLength(250)]
        public string ImageUrl { get; set; }
        
        public ICollection<Property> Properties { get; set; }
    }
}