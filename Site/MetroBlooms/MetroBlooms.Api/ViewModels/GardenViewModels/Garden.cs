using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.JsonConverters;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels.GardenViewModels
{
    public class Garden
    {
        public GardenAddress Address { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date_Created { get; set; }

        public GardenFeatures Features { get; set; }
        public int Garden_Id { get; set; }
        public Gardener Gardener { get; set; }
        public string Name_Of_Garden { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool No_Longer_Exists { get; set; }

        public string Noteworthy_Features { get; set; }
        public string Uploaded_Image { get; set; }
    }
}