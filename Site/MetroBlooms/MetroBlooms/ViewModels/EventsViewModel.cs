using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;
using MetroBlooms.ViewModels.Generic;

using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels
{
    public class EventsViewModel : GenericViewModel
    {
        public EventsViewModel(Node contextNode) : base(contextNode)
        {
        }

        public List<Event> Events { get; set; }
    }
}