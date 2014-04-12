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
        public string PageKeywords { get; set; }


        public HeadViewModel()
        {
            Node currentNode = uQuery.GetCurrentNode();
            //Our node is null, return early.
            if (currentNode == null) return;

            var title = currentNode.GetProperty<string>("pageTitle");
            PageTitle = title.IsSet() ? title : currentNode.Name;
            PageDescription = currentNode.GetProperty<string>("pageDescription");
            PageAuthor = currentNode.GetProperty<string>("pageAuthor");
            PageKeywords = currentNode.GetProperty<string>("pageKeywords");
        }

    }
}