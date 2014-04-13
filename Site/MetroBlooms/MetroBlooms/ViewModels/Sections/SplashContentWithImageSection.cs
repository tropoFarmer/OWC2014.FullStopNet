using MetroBlooms.Extensions;
using MetroBlooms.Utilities;
using uComponents.DataTypes.UrlPicker.Dto;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class SplashContentWithImageSection : BaseSection
    {
        public UmbracoPropertyString Title { get; set; }
        public string Text { get; set; }
        public UmbracoImage BackgroundImage { get; set; }
        public UrlPickerState CTA { get; set; }
        public string BackgroundColor { get; set; }
        public string Size { get; set; }
        public string Alignment { get; set; }
        public string Theme { get; set; }
        
        public SplashContentWithImageSection(Node node) : base(node)
        {
            if (node == null) return;
            Title = new UmbracoPropertyString(node, "title");
            Text = new UmbracoPropertyString(node, "text");
            BackgroundImage = node.GetImage("backgroundImage");
            BackgroundColor = node.GetProperty<string>("backgroundColor");
            CTA = UrlPickerState.Deserialize(node.GetProperty<string>("cta"));
            Size = node.GetProperty<string>("Size");
            Alignment = node.GetProperty<string>("Alignment");
            Theme = node.GetProperty<string>("Theme");
        }
    }
}