using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.ViewModels;

using umbraco;
using MetroBlooms.Extensions;
using Umbraco.Web.Mvc;
using MetroBlooms.ViewModels.Global;
using System.Web;
using System.IO;
using System.Drawing;
using MetroBlooms.Utilities.ImageProcessor;

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

        public ImageResult HandleImage(string file, int width = 0, int height = 0, string anchor = "" )
        {
            return new ImageResult(file, width, height, anchor);
        }
    }
}