using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace MetroBlooms.Controllers
{
    public class ExternalController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var node = uQuery.GetCurrentNode();
            return Redirect(node.GetProperty<string>("redirectUrl"));
        }
    }
}