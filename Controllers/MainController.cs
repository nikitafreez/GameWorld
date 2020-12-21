using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

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
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }

        [HttpGet]
        public IActionResult Auth() //complete
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Auth(UserEnter model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserEnter user = await db.UsersEnter.FirstOrDefaultAsync(u => u.User_Nickname == model.User_Nickname && u.User_Password == model.User_Password);
        //        if (user != null)
        //        {
        //            await Authenticate(model.User_Nickname);

        //            return RedirectToAction("/");
        //        }
        //        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}

        //private async Task Authenticate(string userName)
        //{
        //    // создаем один claim
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        //    };
        //    // создаем объект ClaimsIdentity
        //    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //    // установка аутентификационных куки
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Main", "Auth");
        //}


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
