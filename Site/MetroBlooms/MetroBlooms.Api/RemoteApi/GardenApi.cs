using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;
using MetroBlooms.Api.ViewModels.GardenViewModels;

namespace MetroBlooms.Api.RemoteApi
{
    public class GardenApi : ApiBase
    {
        public GardenApi(ApiCredentials apiCredentials)
            : base(apiCredentials)
        {
        }

        public Garden Get(int gardenId)
        {
            return GetSingleFromList<Garden>(string.Format("garden/{0}", gardenId));
        }
    }
}