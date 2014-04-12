using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using System.Text;
using umbraco;
using FullStopNet.Web.ViewModels.Home;


namespace FullStopNet.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Home()
        {
            var currentNode = uQuery.GetCurrentNode();

            return View(new HomeViewModel());
        }
    }
}