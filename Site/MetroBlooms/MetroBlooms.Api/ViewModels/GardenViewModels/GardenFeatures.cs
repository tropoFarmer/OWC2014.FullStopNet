using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.JsonConverters;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels.GardenViewModels
{
    public class GardenFeatures
    {
        [JsonConverter(typeof(BoolConverter))]
        public bool Apartment_Or_Condo { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Business_Garden { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Church_Garden { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Community_Garden { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Container_Or_Windowbox { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Downspouts_Redirected { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Has_Rainbarrel { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Not_Publically_Visible { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Public_Building { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Raingarden { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Residential_Garden { get; set; }
    }
}