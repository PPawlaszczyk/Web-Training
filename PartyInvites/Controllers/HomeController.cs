using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeControler
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Gretting = hour < 17 ? "Dzień dobry" : "Dobry wieczór";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // do zrobienia: wyslij zawartosc guest respone do organizatora  przyjecia
                return View("thanks", guestResponse);
            }
            else
            { //błąd kontorli porpawnosci. Ponownie wyswietla formularz wprowadzenia danycgh
                return View();
            }
        }
    }
}