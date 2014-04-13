using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using MetroBlooms.Api.RemoteApi;
using MetroBlooms.Api.ViewModels.GardenViewModels;
using MetroBlooms.Utilities;

namespace MetroBlooms.ViewModels.Home
{
    public class GardenViewModel : UmbracoView
    {
        public Garden Garden { get; set; }

        public GardenViewModel()
        {
            var api = new GardenApi(Config.ApiCredentials);
            try
            {
                Garden = api.Get(37254);
            }
            catch (WebException ex)
            {
                throw new InvalidOperationException("Unable to connect to API");
            }
            
        }
    }
}