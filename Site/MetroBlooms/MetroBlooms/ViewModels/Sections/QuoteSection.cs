using MetroBlooms.Utilities;
using MetroBlooms.ViewModels.Home;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class QuoteSection : BaseSection
    {
        public UmbracoPropertyString Heading { get; set; }
        public UmbracoPropertyString Quote { get; set; }
        public UmbracoPropertyString Citation { get; set; }

        public QuoteSection(Node node) : base(node)
        {
            if (node == null) return;

            Heading = new UmbracoPropertyString(node, "heading");
            Quote = new UmbracoPropertyString(node, "quote");
            Citation = new UmbracoPropertyString(node, "citation");
        }
    }
}