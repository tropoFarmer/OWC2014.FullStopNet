using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    public class QuoteSection : BaseSection
    {
        public string Heading { get; set; }
        public string Quote { get; set; }
        public string Citation { get; set; }

        public QuoteSection(Node node) : base(node)
        {
            if (node == null) return;

            Heading = node.GetProperty<string>("heading");
            Quote = node.GetProperty<string>("quote");
            Citation = node.GetProperty<string>("citation");
        }
    }
}