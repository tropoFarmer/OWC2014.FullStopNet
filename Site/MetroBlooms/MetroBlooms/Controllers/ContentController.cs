using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.ViewModels;

using umbraco;
using MetroBlooms.Extensions;

using Umbraco.Core.Models;

using umbraco.NodeFactory;

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

        public ActionResult UpdateContent(UpdateContentParams updateContentParams)
        {
            var cs = ApplicationContext.Services.ContentService;
            var node = cs.GetById(updateContentParams.NodeId);
            node.SetValue(updateContentParams.PropertyName, updateContentParams.Value);
            cs.SaveAndPublish(node);
            return Content(string.Format("Successfully saved property: {0}", updateContentParams.PropertyName));
        }

        public ImageResult HandleImage(string file, int width = 0, int height = 0, string anchor = "" )
        {
            return new ImageResult(file, width, height, anchor);
        }
    }

    public class UpdateContentParams
    {
        private string _value;
        public int NodeId { get; set; }
        public string PropertyName { get; set; }

        [AllowHtml]
        public string Value
        {
            get { return _value; }
            set { _value = value.Replace("<b>", "<strong>").Replace("</b>", "</strong>").Replace("<i>", "<em>").Replace("</i>", "</em>"); }
        }
    }
}