using MetroBlooms.Utilities;
using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Global
{
    public class FootViewModel
    {
        public static string GoogleAnalyticsKey { get; set; }
        public static string GoogleAnalyticsDomain { get; set; }

        public FootViewModel()
        {
            Node node = uQuery.GetCurrentNode();
            GoogleAnalyticsKey = Config.GoogleAnalyticsKey;
            GoogleAnalyticsDomain = Config.GoogleAnalyticsDomain;
        }
    }
}