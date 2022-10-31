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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<User> users = new List<User>()
            {
                new User() {Id=1,Name="Test User", Email="test@user.com", Phone="46846",Password="klNXie2gONbAFWzwUiirfA==",PasswordSalt ="t3X+Iy31sX8PpOFwe8zPMw==" }
            };
            modelBuilder.Entity<User>().HasData(users);

            List<Category> categories = new List<Category>()
            {
                new Category() {Id=1,Name="Home", ImageUrl="/home.png"},
                new Category() {Id=2,Name="Apartment", ImageUrl="/Apartment.png"},
                new Category() {Id=3,Name="Land", ImageUrl="/Land.png"}
            };
            modelBuilder.Entity<Category>().HasData(categories);

            List<Property> properties = new List<Property>()
            {
                new Property() {Id=1,Name="Small home", Address="test address no. 1", Detail="2 beadrooms, kitchen, 1 bathroom", CategoryId=1,ImageUrl="smallhome.png", IsTrending= false,Price=55000,UserId=1 }, 
            };
            modelBuilder.Entity<Property>().HasData(properties);
        }
    }
}