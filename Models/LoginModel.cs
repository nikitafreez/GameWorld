using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameWorld.Models
{
    public class LoginModel
    {


        [Required(ErrorMessage = "Не указан ник")]
        public string User_Nickname { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
    }
}
