using MVCFirstApp.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 15)]
        public String Index()
        {
            return "This is Home Controller";
            //return RedirectToAction("GetAllCustomers", "Customer");
        }

        [OutputCache(Duration = 20)] // met en cache la date actuelle dans un buffer pendant 20 secondes
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            //return DateTime.Now.ToString("T");
            return TimeString();
        }
         
        [NonAction] // la fonction TimeString n'est pas une Action routé
        public string TimeString()
        {
            return "Time is " + DateTime.Now.ToString("T");
        }

        public ActionResult MyView()
        {
            return View();
        }
    }
}