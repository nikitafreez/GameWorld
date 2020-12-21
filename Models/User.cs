using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameWorld.Models
{
    public class UserEnter
    {
        [Required(ErrorMessage = "Не указан ник")]
        public string User_Nickname { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
    }

    public class UserEnterContext : DbContext
    {
        public DbSet<UserEnter> Users { get; set; }
        public UserEnterContext(DbContextOptions<UserEnterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
