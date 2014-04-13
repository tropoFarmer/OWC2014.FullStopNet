using MetroBlooms.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using MetroBlooms.Extensions;

namespace MetroBlooms.ViewModels.Home
{
    public class HomeViewModel : UmbracoView
    {
<<<<<<< HEAD
        public string MainContent { get; set; }
        public UmbracoImage Image { get; set; }
=======
        public HtmlString MainContent { get; set; }
>>>>>>> ec99f5e709c8d177c3671ceeff54d6aa0cc6bd14

        public HomeViewModel()
        {
            var currentNode = uQuery.GetCurrentNode();
            this.MainContent = currentNode.GetProperty<string>("mainContent");
            this.Image = currentNode.GetImage("image");
        }
    }
}