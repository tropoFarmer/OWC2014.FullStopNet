using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using MetroBlooms.Api.ViewModels;

using Newtonsoft.Json;

namespace MetroBlooms.Api.RemoteApi
{
    public abstract class ApiBase
    {
        protected ApiBase(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        protected const string RootUrl = "http://www.metroblooms.org/api/";
        protected string SessionToken { get; set; }

        protected List<T> GetList<T>(string relativeUrl)
        {
            Authenticate();
            using (var webClient = new WebClient())
            {
                var stringResult = webClient.DownloadString(string.Format("{0}{1}?token={2}", RootUrl, relativeUrl, SessionToken));
                var result = JsonConvert.DeserializeObject<List<T>>(stringResult);
                return result;
            }
        }

        protected T GetSingleFromList<T>(string relativeUrl)
        {
            return GetList<T>(relativeUrl).FirstOrDefault();
        }

        protected void Authenticate()
        {
            if (SessionToken != null)
            {
                return;
            }

            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var htmlResult = wc.UploadString(RootUrl + "auth/login", string.Format("user={0}&pwd={1}", UserName, Password));
                var result = JsonConvert.DeserializeObject<LoginResult>(htmlResult);
                SessionToken = result.SessionToken;
            }
        }

        private string UserName { get; set; }
        private string Password { get; set; }
    }
}