using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.JsonConverters;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels
{
    public class Evaluator
    {
        public int Evaluator_Id { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Evaluator_Notified { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}