using System.Security.Permissions;
using MetroBlooms.Utilities;
using umbraco;
using umbraco.NodeFactory;
using System.Linq;
using System.Collections.Generic;

namespace MetroBlooms.ViewModels.Generic
{
    public class GenericViewModel : UmbracoView
    {
        public string Content { get; set; }
        public List<Node> SubLinks { get; set; }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;

            Content = contextNode.GetProperty<string>("content");
        }
    }
}