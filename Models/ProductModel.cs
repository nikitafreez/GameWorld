using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameWorld.Models
{
    public class Product
    {
        [Key]
        public int ID_Product { get; set; } = 1;
        public string Product_Title { get; set; }
        public string Product_Description { get; set; }
        public int Product_Price { get; set; }
        public string Product_Image { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserEnter> UsersEnter { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }


}
