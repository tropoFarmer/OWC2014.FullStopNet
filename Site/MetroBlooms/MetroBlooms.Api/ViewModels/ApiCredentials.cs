using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroBlooms.Api.ViewModels
{
    public class ApiCredentials
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _rootApiUrl;

        public ApiCredentials(string userName, string password, string rootApiUrl)
        {
            _userName = userName;
            _password = password;
            _rootApiUrl = rootApiUrl;
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }

        public string RootApiUrl
        {
            get { return _rootApiUrl; }
        }
    }
}