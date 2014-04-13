using MetroBlooms.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using MetroBlooms.Extensions;
using MetroBlooms.ViewModels.Sections;

using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Home
{
    public class HomeViewModel : UmbracoView
    {
        public List<BaseSection> Sections { get; set; }

        public HomeViewModel()
        {
            var currentNode = uQuery.GetCurrentNode();
            this.Sections = this.FetchSections(currentNode);
        }
    }


}