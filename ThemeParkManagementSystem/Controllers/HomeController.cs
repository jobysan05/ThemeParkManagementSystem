using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemeParkManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Rides()
        {
            ViewBag.Message = "Your Rides page.";

            return View();
        }

        public ActionResult Shops()
        {
            ViewBag.Message = "Your Shops page.";

            return View();
        }

        public ActionResult Staff()
        {
            ViewBag.Message = "Your Staff page.";

            return View();
        }

        public ActionResult Guests()
        {
            ViewBag.Message = "Your Guests page.";

            return View();
        }
    }
}