using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;
using umbraco;

namespace MetroBlooms.ViewModels.Generic
{
    public class GenericViewModel : UmbracoView
    {
        public string Content { get; set; }
        public GenericViewModel() { }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;

            this.Content = contextNode.GetProperty<string>("content");
        }
    }
}