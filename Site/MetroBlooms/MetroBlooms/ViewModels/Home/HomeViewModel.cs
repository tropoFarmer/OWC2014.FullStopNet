using MetroBlooms.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using MetroBlooms.Extensions;
using MetroBlooms.ViewModels.Sections;

using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Home
{
    public class HomeViewModel : UmbracoView
    {
        public UmbracoPropertyString MainContent { get; set; }
        public UmbracoImage Image { get; set; }
        public List<BaseSection> Sections { get; set; }

        public HomeViewModel()
        {
            var currentNode = uQuery.GetCurrentNode();
            
            this.MainContent = new UmbracoPropertyString(currentNode, "mainContent");
            string str = MainContent;
            this.Image = currentNode.GetImage("image");
            this.Sections = this.FetchSections(currentNode);
        }
    }

    public class UmbracoPropertyString : IHtmlString
    {
        private readonly int _nodeId;
        private readonly string _propertyName;
        private readonly string _value;

        public UmbracoPropertyString(Node node, string propertyName) 
        {
            _nodeId = node.Id;
            _propertyName = propertyName;
            _value = node.GetProperty<string>(propertyName);
        }

        public static implicit operator string(UmbracoPropertyString obj)
        {
            return obj._value;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public int NodeId
        {
            get { return _nodeId; }
        }

        public string ToHtmlString()
        {
            return _value;
        }
    }
}