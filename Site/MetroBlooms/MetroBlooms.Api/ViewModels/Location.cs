﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroBlooms.Api.ViewModels
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}