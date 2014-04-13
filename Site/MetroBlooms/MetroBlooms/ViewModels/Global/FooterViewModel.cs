using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uComponents.DataTypes.MultiUrlPicker.Dto;
using uComponents.DataTypes.UrlPicker.Dto;

using umbraco;
using umbraco.NodeFactory;
using MetroBlooms.Extensions;

namespace MetroBlooms.ViewModels.Global
{
    public class FooterViewModel
    {
        public FooterViewModel()
        {
            var homeNode = uQuery.GetNodeByUrl("/");
            this.Address = homeNode.GetProperty<string>("address");
            this.Phone = homeNode.GetProperty<string>("phone");
            this.Email = homeNode.GetProperty<string>("email");
            this.PrivacyPolicy = UrlPickerState.Deserialize(homeNode.GetProperty<string>("privacyPolicy"));
            this.GetInvolvedLink = UrlPickerState.Deserialize(homeNode.GetProperty<string>("getInvolvedLink"));
        }

        public UrlPickerState GetInvolvedLink { get; set; }
        public UrlPickerState PrivacyPolicy { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}