using System.Collections.Generic;
using MetroBlooms.ViewModels.Sections;
using umbraco;
using umbraco.NodeFactory;
using System.Linq;
using System.Collections.Generic;
using MetroBlooms.Utilities;

namespace MetroBlooms.ViewModels.Generic
{
    public class GenericViewModel : UmbracoView
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Node> SubLinks { get; set; }
        public List<BaseSection> Sections { get; set; }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;

            this.Title = contextNode.Name;
            this.Content = contextNode.GetProperty<string>("content");
            this.SubLinks = this.FetchSubLinks(contextNode);
            this.Sections = FetchSections(contextNode);
        }

        public List<Node> FetchSubLinks(Node nodeContext)
        {
            return nodeContext.GetChildNodes().Where(x => !Config.NonContentAliases.Contains(x.NodeTypeAlias)).ToList();
        }
    }
}