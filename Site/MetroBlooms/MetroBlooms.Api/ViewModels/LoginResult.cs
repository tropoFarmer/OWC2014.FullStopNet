using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.JsonConverters;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels
{
    public class LoginResult
    {
        [JsonConverter(typeof(BoolConverter))]
        public bool Success { get; set; }

        public string Message { get; set; }
        public int User_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string SessionToken { get; set; }
    }
}