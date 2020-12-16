using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWorld.Controllers
{
    public class MainController : Controller
    {
        private ApplicationContext db;

        public MainController(ApplicationContext context)
        {
            this.db = context;
        }
        #region Создание представлений
        public IActionResult Main() //complete
        {
            return View();
        }

        public async Task<IActionResult> Catalog() //complete
        {

            return View(await db.Products.ToListAsync());
        }

        public IActionResult Cart() //complete
        {
            return View();
        }

        public IActionResult Auth() //complete
        {
            return View();
        }

        public IActionResult About() //complete
        {
            return View();
        }

        public IActionResult MyCabinet() //complete
        {
            return View();
        }

        public IActionResult Recovery() //complete
        {
            return View();
        }

        public IActionResult Reg(User user) //complete
        {
            if (ModelState.IsValid)
            {
                Debugger.Log(1, null, "Прошла");
                var newUser = new User
                {
                    User_Nickname = user.User_Nickname,
                    User_Email = user.User_Email,
                    User_Password = user.User_Password,
                    User_Year_Of_Birth = user.User_Year_Of_Birth
                };
                db.Add(newUser);
                db.SaveChanges();

                return View("../Main/Auth");
            }
            else
            {
                Debugger.Log(1, null, "не Прошла");
                return View(user);
            }
        }
        #endregion
    }
}
