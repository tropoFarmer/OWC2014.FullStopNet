using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using umbraco;

namespace MetroBlooms.ViewModels.Home
{
    public class HomeViewModel : UmbracoView
    {
        public HtmlString MainContent { get; set; }
        public HomeViewModel()
        {
            var currentNode = uQuery.GetCurrentNode();
            this.MainContent = new HtmlString(currentNode.GetProperty<string>("mainContent"));
        }
    }
}