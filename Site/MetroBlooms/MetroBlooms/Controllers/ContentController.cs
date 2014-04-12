using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.ViewModels;

using umbraco;

using Umbraco.Web.Mvc;

namespace MetroBlooms.Controllers
{
    public class ContentController : SurfaceController
    {
        public ActionResult Head()
        {
            var currentNode = uQuery.GetCurrentNode();
            return PartialView(new SEO(currentNode));
        }
    }
}