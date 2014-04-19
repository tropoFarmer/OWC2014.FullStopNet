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
        public UmbracoPropertyString Text { get; set; }
        public UrlPickerState CTA { get; set; }
        public UmbracoImage BackgroundImage { get; set; }
        public string BackgroundColor { get; set; }
        public string SectionSize { get; set; }
        public string TitleSize { get; set; }
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
            TitleSize = node.GetProperty<string>("titleSize");
            SectionSize = node.GetProperty<string>("sectionSize");
            Alignment = node.GetProperty<string>("alignment");
            Theme = node.GetProperty<string>("theme");
        }
    }
}