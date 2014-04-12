using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Extensions;

using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Global
{
    public class HeadViewModel
    {
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageAuthor { get; set; }

        public HeadViewModel()
        {
            var currentNode = uQuery.GetCurrentNode();
            //Our node is null, return early.
            if (currentNode == null) return;

            var title = currentNode.GetProperty<string>("pageTitle");
            this.PageTitle = title.IsSet() ? title : currentNode.Name;
            this.PageDescription = currentNode.GetProperty<string>("pageDescription");
            this.PageAuthor = currentNode.GetProperty<string>("pageAuthor");
        }
    }
}