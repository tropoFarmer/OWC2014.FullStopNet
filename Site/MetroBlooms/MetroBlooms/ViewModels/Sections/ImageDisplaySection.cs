using MetroBlooms.Extensions;
using MetroBlooms.Utilities;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class ImageDisplaySection : BaseSection
    {
        public UmbracoImage Image1 { get; set; }
        public UmbracoImage Image2 { get; set; }
        public UmbracoImage Image3 { get; set; }

        public ImageDisplaySection(Node node) : base(node)
        {
            if (node == null) return;

            Image1 = node.GetImage("image1");
            Image2 = node.GetImage("image2");
            Image3 = node.GetImage("image3");
        }
    }
}