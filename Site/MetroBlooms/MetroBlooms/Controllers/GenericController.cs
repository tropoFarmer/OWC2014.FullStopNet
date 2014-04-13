using MetroBlooms.ViewModels.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MetroBlooms.ViewModels.Home;

using umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace MetroBlooms.Controllers
{
    public class GenericController : RenderMvcController
    {

        public override ActionResult Index(RenderModel model)
        {
            var currentNode = uQuery.GetCurrentNode();

            return View("Generic", new GenericViewModel(currentNode));
        }

        public ActionResult ApiTest(RenderModel model)
        {
            return View(new GardenViewModel());
        }
    }
}
