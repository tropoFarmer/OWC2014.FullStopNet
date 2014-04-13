using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.ViewModels.Home;

using umbraco;

namespace MetroBlooms.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Home()
        {
            var currentNode = uQuery.GetCurrentNode();

            var viewModel = new HomeViewModel();

            return View(viewModel);
        }
    }
}