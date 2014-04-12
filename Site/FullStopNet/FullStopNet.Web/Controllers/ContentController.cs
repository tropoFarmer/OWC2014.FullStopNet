using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using umbraco;
using FullStopNet.Web.ViewModels;

namespace FullStopNet.Web.Controllers
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