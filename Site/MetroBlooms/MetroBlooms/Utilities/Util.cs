using System;
using System.Linq;
using System.Web;

namespace MetroBlooms.Utilities
{
    public class Util
    {
        #region Url methods

        public static string GetQueryStringValue(string key)
        {
            var request = HttpContext.Current.Request;
            if (request != null)
            {
                return request.QueryString[key];
            }
            return String.Empty;
        }

        public static string CurrentUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        public static string BaseUrl(string scheme)
        {
            var requestUrl = HttpContext.Current.Request.Url;

            var uriBuilder = new UriBuilder {Scheme = scheme ?? requestUrl.Scheme, Host = requestUrl.Host};

            if (!requestUrl.IsDefaultPort)
            {
                uriBuilder.Port = requestUrl.Port;
            }

            var baseUrl = uriBuilder.ToString();

            if (baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.TrimEnd(new[] {'/'});
            }

            return baseUrl;
        }

        public static string HomeUrl()
        {
            var url = BaseUrl("http"); // Force http
            return url + "/";
        }

        /// <summary>
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="authority">null to preserve existing authority</param>
        /// <returns></returns>
        public static string Absolute(string relativeOrAbsolute, string authority = null)
        {
            var uri = new Uri(relativeOrAbsolute, UriKind.RelativeOrAbsolute);

            if (uri.IsAbsoluteUri)
            {
                return relativeOrAbsolute;
            }

            relativeOrAbsolute = VirtualPathUtility.ToAbsolute(relativeOrAbsolute);

            return BaseUrl(authority) + relativeOrAbsolute;
        }

        public static void RedirectIfHttps()
        {
            if (IsHttps())
            {
                var url = BaseUrl("http") + HttpContext.Current.Request.RawUrl;
                HttpContext.Current.Response.Redirect(url);
                HttpContext.Current.Response.End();
            }
        }

        public static bool StartsWithHttp(string url)
        {
            return url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                   url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsHttps()
        {
            // Note: X-Forwarded-Proto header is expected to be sent from the Load Balancer
            var request = HttpContext.Current.Request;
            return request.IsSecureConnection || request.Headers["X-Forwarded-Proto"] == "https";
        }

        public static string UrlCombine(string url1, string url2)
        {
            if (String.IsNullOrEmpty(url1))
                return url2;
            if (String.IsNullOrEmpty(url2))
                return url1;

            url1 = url1.TrimEnd('/');
            url2 = url2.TrimStart('/');

            return String.Format("{0}/{1}", url1, url2);
        }

        public static string EnsureUrlEndsWithSlash(string url)
        {
            return url.Last() == '/'
                ? url
                : url + '/';
        }

        #endregion Url methods
    }
}