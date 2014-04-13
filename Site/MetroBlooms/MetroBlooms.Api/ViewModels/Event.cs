using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroBlooms.Api.ViewModels
{
    public class Event
    {
        public string Id { get; set; }
        public string Workshop_Desc_Id { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public DateTime? Endtime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}