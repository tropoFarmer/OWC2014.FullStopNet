using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;
using umbraco;

namespace MetroBlooms.Utilities
{
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