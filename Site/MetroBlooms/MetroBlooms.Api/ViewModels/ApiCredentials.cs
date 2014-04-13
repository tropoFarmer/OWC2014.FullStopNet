using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroBlooms.Api.ViewModels
{
    public class ApiCredentials
    {
        private readonly string _userName;
        private readonly string _password;

        public ApiCredentials(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}