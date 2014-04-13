using System;
using System.Collections.Generic;

using MetroBlooms.Api.ViewModels;

namespace MetroBlooms.Api.RemoteApi
{
    public class EventApi : ApiBase
    {
        public EventApi(ApiCredentials apiCredentials)
            : base(apiCredentials)
        {
        }

        public List<Event> GetAllEvents()
        {
            return GetList<Event>("event");
        }
    }
}