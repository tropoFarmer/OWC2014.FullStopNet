using System.Collections.Generic;
using MetroBlooms.ViewModels.Sections;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Generic
{
    public class GenericViewModel : UmbracoView
    {
        public string Content { get; set; }
        public List<BaseSection> Sections { get; set; }

        public GenericViewModel()
        {
        }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;
            Content = contextNode.GetProperty<string>("content");
            Sections = FetchSections(contextNode);
        }
    }
}