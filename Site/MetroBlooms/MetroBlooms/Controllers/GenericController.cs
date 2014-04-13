using MetroBlooms.Api.RemoteApi;
using MetroBlooms.Utilities;
using MetroBlooms.ViewModels;
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

        public ActionResult Events(RenderModel model)
        {
            var api = new EventApi(Config.ApiCredentials);
            var events = api.GetAllEvents();
            var currentNode = uQuery.GetCurrentNode();

            var viewModel = new EventsViewModel(currentNode);
            viewModel.Events = events;
            return View("Events", viewModel);
        }
    }
}
