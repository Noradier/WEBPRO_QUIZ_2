using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace student_database.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static string ApiKey = "AIzaSyAp9xTxFodpDQ-tDXz9_9l9gwrUK2Eu93c";
        private static string AuthEmail = "";
        private static string AuthPassword = "";
        private static string Bucket = "https://student-database-6602f.firebaseio.com/";

        public ActionResult Index()
        {
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