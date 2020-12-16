using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameWorld.Models
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }


        [Required (ErrorMessage = "Не указан ник")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Длина ника должна быть от 3 до 12 символов")]
        public string User_Nickname { get; set; }


        [Required(ErrorMessage = "Не указана почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректо указана почта")]
        public string User_Email { get; set; }


        [Required (ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 30 символов")]
        public string User_Password { get; set; }
        

        [Required(ErrorMessage = "Не указан год рождения")]
        [Range(1910, 2006, ErrorMessage = "Недопустимый возраст")]
        public int User_Year_Of_Birth { get; set; }
    }

    public class SaveContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public SaveContext(DbContextOptions<SaveContext> options) : base(options)
        {

        }
    }
}
