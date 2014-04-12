using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroBlooms.Api.ViewModels.GardenViewModels
{
    public class GardenAddress
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}