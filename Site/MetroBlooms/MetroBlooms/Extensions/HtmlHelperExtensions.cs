using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using MetroBlooms.Utilities;
using MetroBlooms.ViewModels.Home;

namespace MetroBlooms.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string EditableClass<T>(this HtmlHelper<T> helper)
        {
            return Config.IsUmbracoUserLoggedIn ? "js-editable" : "";
        }

        public static string EditableData<T>(this HtmlHelper<T> helper, UmbracoPropertyString property)
        {
            return Config.IsUmbracoUserLoggedIn ? string.Format("data-nodeid=\"{0}\" data-propertyname=\"{1}\"", property.NodeId, property.PropertyName) : "";
        }
    }
}