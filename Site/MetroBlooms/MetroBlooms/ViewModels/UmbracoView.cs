using MetroBlooms.ViewModels.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.NodeFactory;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using umbraco;
using MetroBlooms.Utilities;

namespace MetroBlooms.ViewModels
{
    public class UmbracoView : RenderModel
    {
        //Allows for empty constructor. Instantiates IPublishedContent from current context
        public UmbracoView() : this(new UmbracoHelper(UmbracoContext.Current).TypedContent(UmbracoContext.Current.PageId)) { }

        public UmbracoView(IPublishedContent content) : base(content) { }

        public List<BaseSection> FetchSections(Node nodeContext)
        {
            var sectionFolder = nodeContext.GetChildNodesByType("SectionsFolder").FirstOrDefault();
            if (sectionFolder == null) return new List<BaseSection>();

            return sectionFolder.GetChildNodes().Select(x => SectionFactory.FetchSectionByNode(x)).ToList();
        }
    }
}