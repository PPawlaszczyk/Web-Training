using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
using Ninject;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
         private IValueCalculator calc;
        
            Produkt[] produkty =
        {
                new Produkt { Name = "kajak", Price = 275M, Category="Sporty wodne" },
                new Produkt { Name = "kamizelka", Price = 49.89M,Category="Sporty wodne" },
                new Produkt { Name = "pilka", Price = 19.50M,Category="Pilka nozna" },
                new Produkt { Name = "flaga", Price = 34.95M ,Category="Pilka nozna" }
        };

        //public ActionResult Index()
        //{
        //    IValueCalculator calc = new LinqValueCalculator();
        //    ShoppingCart_LINQ cart = new ShoppingCart_LINQ(calc) { Produkts = produkty };
        //    decimal totalValue = cart.CalculateProductTotal();
        //    return View(totalValue);
        //}

            public HomeController(IValueCalculator calcParm)
        {
            calc = calcParm;
        }

        public ActionResult Index()
        {


            ShoppingCart_LINQ cart = new ShoppingCart_LINQ(calc) { Produkts = produkty };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

    }
}