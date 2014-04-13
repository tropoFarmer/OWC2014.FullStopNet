using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels.GardenViewModels;

namespace MetroBlooms.Api.RemoteApi
{
    public class GardenApi : ApiBase
    {
        public GardenApi(string userName, string password) : base(userName, password)
        {
        }

        public Garden Get(int gardenId)
        {
            return GetSingleFromList<Garden>(string.Format("garden/{0}", gardenId));
        }
    }
}