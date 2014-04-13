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
        public List<LinkViewModel> SubLinks { get; set; }
        public List<BaseSection> Sections { get; set; }

        public GenericViewModel(Node contextNode)
        {
            if (contextNode == null) return;

            this.Title = contextNode.Name;
            this.Content = contextNode.GetProperty<string>("content");
            var linkContext = this.FetchLinkContext(contextNode);
            this.SubLinks = this.FetchSubLinks(linkContext);
            this.Sections = FetchSections(contextNode);
        }

        private List<LinkViewModel> FetchSubLinks(Node nodeContext)
        {
            return nodeContext.GetChildNodes()
                .Where(x => !Config.NonContentAliases.Contains(x.NodeTypeAlias))
                .Select(x => new LinkViewModel(x)
                {
                    ChildLinks = x.Level == 3 ? this.FetchSubLinks(x) : new List<LinkViewModel>()
                }).ToList();
        }

        private Node FetchLinkContext(Node currentNode)
        {
            return currentNode.Level == 2 ? currentNode : currentNode.GetAncestorByPathLevel(2);
        }

    }
}