using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;

using umbraco;
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
                return new ApiCredentials(userName, password);
            }
        }

        private static T GetConfigSetting<T>(string name)
        {
            if (_settingsNode == null) return default(T);
            return _settingsNode.GetProperty<T>(name);
        }
    }
}