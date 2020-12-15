using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Reg() //complete
        {
            return View();
        }
        #endregion
    }
}
