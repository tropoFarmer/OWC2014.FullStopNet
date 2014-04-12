﻿using System;
using System.Collections.Generic;
using System.Linq;

using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace MetroBlooms.ViewModels
{
    public class UmbracoView : RenderModel
    {
        //Allows for empty constructor. Instantiates IPublishedContent from current context
        public UmbracoView() : this(new UmbracoHelper(UmbracoContext.Current).TypedContent(UmbracoContext.Current.PageId)) { }

        public UmbracoView(IPublishedContent content) : base(content) { }
    }
}