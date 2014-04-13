using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;

namespace MetroBlooms.ViewModels
{
    public class EventsViewModel : UmbracoView
    {
        public List<Event> Events { get; set; }
    }
}