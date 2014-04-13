using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;
using umbraco;
using MetroBlooms.Extensions;
using uComponents.DataTypes.UrlPicker.Dto;

namespace MetroBlooms.ViewModels
{
    public class LinkViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public bool Active { get; set; }
        public List<LinkViewModel> ChildLinks = new List<LinkViewModel>();

        public LinkViewModel(Node node)
        {
            if (node == null) return;

            this.Title = node.Name;
            this.Url = node.Url;
            var redirectUrl = node.GetProperty<string>("redirectUrl");
            this.NewWindow = redirectUrl.IsSet();

        }

        public LinkViewModel(UrlPickerState picker)
        {
            this.Title = picker.Title;
            this.Url = picker.Url;
            this.NewWindow = picker.NewWindow;
        }
    }
}