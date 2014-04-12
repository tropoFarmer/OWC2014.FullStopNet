using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.ViewModels;

using umbraco;

using Umbraco.Web.Mvc;
using MetroBlooms.ViewModels.Global;

namespace MetroBlooms.Controllers
{
    public class ContentController : SurfaceController
    {
        public ActionResult Head()
        {
            
            return PartialView(new HeadViewModel());
        }

        public ActionResult Header()
        {
            return PartialView(new HeaderViewModel());
        }

        public ActionResult Footer()
        {
            return PartialView(new FooterViewModel());
        }

        public ActionResult Foot()
        {
            return PartialView(new FootViewModel());
        }
    }
}