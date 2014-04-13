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
    public class HeaderViewModel
    {
        public MultiUrlPickerState UtilityLinks { get; set; }
        public MultiUrlPickerState MainNavigation { get; set; }

        public HeaderViewModel()
        {
            var node = uQuery.GetCurrentNode();
            this.MainNavigation = this.FetchNavigationLinks(node);
            this.UtilityLinks = this.FetchUtilityLinks(node);
        }

        private MultiUrlPickerState FetchUtilityLinks(Node nodeContext)
        {
            return MultiUrlPickerState
                .Deserialize(nodeContext.GetPropertyRecursive<string>("utilityLinks"));
        }

        private MultiUrlPickerState FetchNavigationLinks(Node nodeContext)
        {
            return MultiUrlPickerState
                .Deserialize(nodeContext.GetPropertyRecursive<string>("navigationLinks"));
        }
    }
}