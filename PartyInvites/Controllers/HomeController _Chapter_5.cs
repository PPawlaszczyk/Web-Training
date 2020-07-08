using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;


namespace PartyInvites.Controllers
{
    public class HomeController_Chapter_5 : Controller
    {
        Produkt_Razor myProdukt = new Produkt_Razor
        {
            ProductID = 1,
            Name = "kajak",
            Description = "Jedonosobowa lodz",
            Category = "Sport wodne",
            Price = 275M
        };
        public ActionResult Index_Chapter_5()
        {
            return View(myProdukt);
        }
        public ActionResult NameandPrice()
        {
            return View(myProdukt);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Suppiler = null;
            return View(myProdukt);

        }
        public ActionResult demoArray()
        {
            Produkt_Razor[] array =
        {
                new Produkt_Razor { Name = "kajak", Price = 275M },
                new Produkt_Razor { Name = "kamizelka", Price = 49.89M },
                new Produkt_Razor { Name = "pilka", Price = 19.50M },
                new Produkt_Razor { Name = "flaga", Price = 34.95M }
        };
            return View(array);
        }
    }
}