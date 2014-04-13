using System.Web;
using System.Web.Mvc;
using MetroBlooms.Utilities;

namespace MetroBlooms.Extensions
{
    public static class GeneralExtensions
    {
        public static string HtmlEncode(this string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

        public static string HtmlDecode(this string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        public static string Absolute(this UrlHelper url, string relativeOrAbsolute, string authority = null)
        {
            return Util.Absolute(relativeOrAbsolute, authority);
        }
    }
}