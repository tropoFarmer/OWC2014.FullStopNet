using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MetroBlooms.Api.JsonConverters;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels
{
    public class Event
    {
        public string Id { get; set; }
        public string Workshop_Desc_Id { get; set; }
        public string Type { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Endtime { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }

        public IHtmlString LocationString
        {
            get
            {
                var strings = new[] { Location.Name, Location.Address1, Location.Address2, string.Format("{0}, {1} {2}", Location.City, Location.State, Location.Zip) }.Where(s => !string.IsNullOrEmpty(s));
                return new HtmlString(string.Join("<br/>", strings));
            }
        }
        public string GoogleMapUrlString
        {
            get
            {
                var strings = new[] { Location.Name, Location.Address1, Location.Address2, string.Format("{0}, {1} {2}", Location.City, Location.State, Location.Zip) }.Where(s => !string.IsNullOrEmpty(s));


                return "http://maps.google.com/?q=" + string.Join(",", strings);
            }
        }
    }
}