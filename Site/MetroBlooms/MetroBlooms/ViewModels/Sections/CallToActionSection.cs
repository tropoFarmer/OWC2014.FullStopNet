using MetroBlooms.Extensions;
using MetroBlooms.Utilities;
using uComponents.DataTypes.UrlPicker.Dto;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class CallToActionSection : BaseSection
    {
        public UmbracoPropertyString Title { get; set; }
        public UmbracoPropertyString Text { get; set; }
        public UrlPickerState CTA { get; set; }
        public string Alignment { get; set; }
        public UmbracoImage Image { get; set; }
        public string ImageSize { get; set; }

        public CallToActionSection(Node node) : base(node)
        {
            if (node == null) return;

            Title = new UmbracoPropertyString(node, "title");
            Text = new UmbracoPropertyString(node, "text");
            CTA = UrlPickerState.Deserialize(node.GetProperty<string>("cta"));
            Alignment = node.GetProperty<string>("alignment");
            Image = node.GetImage("image");
            ImageSize = node.GetProperty<string>("imageSize");
        }
    }
}