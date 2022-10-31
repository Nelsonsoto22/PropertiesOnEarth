using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertiesOnEarthAPI.Models;

namespace PropertiesOnEarthAPI.DataAccess
{
    public class PropertiesOnEarthDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }

        public PropertiesOnEarthDBContext(DbContextOptions<PropertiesOnEarthDBContext> options) : base(options)
        {
            
        }
    }
}