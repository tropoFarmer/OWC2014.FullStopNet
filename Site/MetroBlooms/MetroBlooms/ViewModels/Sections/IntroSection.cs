using MetroBlooms.Utilities;
using MetroBlooms.ViewModels.Home;
using uComponents.DataTypes.UrlPicker.Dto;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class IntroSection : BaseSection
    {
        public UmbracoPropertyString Title { get; set; }
        public UrlPickerState CTA1 { get; set; }
        public UrlPickerState CTA2 { get; set; }
        public string Alignment { get; set; }

        public IntroSection(Node node) : base(node)
        {
            if (node == null) return;

            Title = new UmbracoPropertyString(node, "title");
            CTA1 = UrlPickerState.Deserialize(node.GetProperty<string>("cta1"));
            CTA2 = UrlPickerState.Deserialize(node.GetProperty<string>("cta2"));
            Alignment = node.GetProperty<string>("Alignment");
        }
    }
}