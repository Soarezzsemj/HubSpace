using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;


namespace HubSpace.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            //Console.WriteLine($"Hashed Password: {hashedPassword}");

            
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}