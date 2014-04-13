using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uComponents.DataTypes.MultiUrlPicker.Dto;
using umbraco;
using umbraco.NodeFactory;
using MetroBlooms.Extensions;

namespace MetroBlooms.ViewModels.Global
{
    public class FootViewModel
    {

        public FootViewModel()
        {
            var node = uQuery.GetCurrentNode();
        }
    }
}