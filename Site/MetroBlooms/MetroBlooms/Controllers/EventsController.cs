using System.Collections.Generic;
using System.Web.Mvc;

using MetroBlooms.Api.RemoteApi;
using MetroBlooms.Utilities;
using MetroBlooms.Utilities.ImageProcessor;
using MetroBlooms.ViewModels;
using MetroBlooms.ViewModels.Global;

using Umbraco.Web.Mvc;

namespace MetroBlooms.Controllers
{
    public class EventsController : SurfaceController
    {
        public ActionResult ListEvents()
        {
            var api = new EventApi(Config.ApiCredentials);
            var events = api.GetAllEvents();
            var viewModel = new EventsViewModel();
            viewModel.Events = events;
            return PartialView(viewModel);
        }


    }
}