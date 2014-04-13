using MetroBlooms.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MetroBlooms.ViewModels.Home;

using umbraco.NodeFactory;
using umbraco;
using MetroBlooms.Extensions;


namespace MetroBlooms.ViewModels.Sections
{
    public class ContentWithImageSection : BaseSection
    {
        public UmbracoPropertyString Text { get; set; }
        public UmbracoImage Image { get; set; }
        public string ImageLocation { get; set; }
        public string ImageSize { get; set; }

        public ContentWithImageSection(Node node) : base(node)
        {
            if (node == null) return;

            this.Text = new UmbracoPropertyString(node, "text");
            this.Image = node.GetImage("image");
            this.ImageLocation = node.GetProperty<string>("imageLocation");
            this.ImageSize = node.GetProperty<string>("imageSize");
        }
    }
}