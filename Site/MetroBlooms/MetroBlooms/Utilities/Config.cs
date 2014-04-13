using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;

using umbraco;
using umbraco.BusinessLogic;
using umbraco.NodeFactory;

namespace MetroBlooms.Utilities
{
    /// <summary>
    /// Configuration settings that come from web.config / Settings node
    /// </summary>
    /// 
    public static class Config
    {
        private static Node _settingsNode
        {
            get
            {
                return uQuery.GetNodesByName("Settings").FirstOrDefault();
            }

        }

        /// <summary>
        /// How long to cache media items from Umbraco in seconds
        /// </summary>
        public static int UmbracoImageCache
        {
            get { return GetConfigSetting<int>("imageCacheInSeconds"); }
        }

        /// <summary>
        /// Credentials for API
        /// </summary>
        public static ApiCredentials ApiCredentials
        {
            get
            {
                var userName = GetConfigSetting<string>("apiUserName");
                var password = GetConfigSetting<string>("apiPassword");
                var rootApiUrl = GetConfigSetting<string>("rootApiUrl");
                return new ApiCredentials(userName, password, rootApiUrl);
            }
        }

        public static string SiteTitle
        {
            get { return GetConfigSetting<string>("siteTitle"); }
        }

        #region Analytics

        public static string GoogleAnalyticsKey
        {
            get { return GetConfigSetting<string>("googleAnalyticsKey"); }
        }

        public static string GoogleAnalyticsDomain
        {
            get { return GetConfigSetting<string>("googleAnalyticsDomain"); }
        }

        #endregion Analytics

        #region Social

        public static string FacebookId
        {
            get { return GetConfigSetting<string>("facebookID"); }
        }

        public static string TwitterHandle
        {
            get { return GetConfigSetting<string>("twitterHandle"); }
        }

        public static string LinkedInId
        {
            get { return GetConfigSetting<string>("linkedInID"); }
        }

        public static string PinterestId
        {
            get { return GetConfigSetting<string>("pinterestID"); }
        }

        #endregion Social


        private static T GetConfigSetting<T>(string name)
        {
            if (_settingsNode == null) return default(T);
            return _settingsNode.GetProperty<T>(name);
        }

        public static bool IsUmbracoUserLoggedIn
        {
            get
            {
                var user = User.GetCurrent();
                var isAdmin = user != null;
                return isAdmin;
            }
        }
    }
}