using System.Security.Permissions;
using MetroBlooms.Utilities;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Generic
{
    public class GenericViewModel : UmbracoView
    {
        public string Content { get; set; }

        public GenericViewModel()
        {
        }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;

            Content = contextNode.GetProperty<string>("content");
        }
    }
}