using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Extensions;

using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels
{
    public class SEO
    {
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageAuthor { get; set; }

        public SEO(Node node)
        {
            //Our node is null, return early.
            if (node == null) return;

            var title = node.GetProperty<string>("pageTitle");
            this.PageTitle = title.IsSet() ? title : node.Name;
            this.PageDescription = node.GetProperty<string>("pageDescription");
            this.PageAuthor = node.GetProperty<string>("pageAuthor");
        }
    }
}