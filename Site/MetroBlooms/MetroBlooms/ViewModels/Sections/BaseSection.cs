using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;

namespace MetroBlooms.ViewModels.Sections
{
    /// <summary>
    /// Base Section used to set the Node context for
    /// pulling section properties from
    /// </summary>
    public class BaseSection
    {
        public Node NodeContext { get; set; }
        public BaseSection(Node node)
        {
            this.NodeContext = node;
        }
    }
}