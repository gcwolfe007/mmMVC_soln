using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mmMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {




            ViewBag.Message = "Don't Overpay. Book Online & Save! ";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Renters()
        {
            ViewBag.Message = "This is Tenants Home";
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
