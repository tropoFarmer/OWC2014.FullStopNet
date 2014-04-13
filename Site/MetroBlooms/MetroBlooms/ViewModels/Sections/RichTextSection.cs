using MetroBlooms.Utilities;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class RichTextSection : BaseSection
    {
        public UmbracoPropertyString Heading { get; set; }
        public UmbracoPropertyString Text { get; set; }

        public RichTextSection(Node node) : base(node)
        {
            if (node == null) return;

            Heading = new UmbracoPropertyString(node, "heading");
            Text = new UmbracoPropertyString(node, "text");
        }
    }
}