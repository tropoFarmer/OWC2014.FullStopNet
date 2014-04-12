using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MetroBlooms.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
