using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GameWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWorld.Controllers
{
    public class CartController : Controller
    {
        private ApplicationContext db;

        public CartController(Models.ApplicationContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.Add(db.Products.Find(ID));
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("/Main/Catalog");
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);
            Cart cart = new Cart();
            if(HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.RemoveAt(number);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("/Main/Cart");
        }
    }
}
