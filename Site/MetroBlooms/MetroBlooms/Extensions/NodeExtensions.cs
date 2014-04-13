using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Utilities;

using uComponents.DataTypes.MultiUrlPicker.Dto;

using umbraco;
using umbraco.NodeFactory;

namespace MetroBlooms.Extensions
{
    public static class NodeExtensions
    {
         /// <summary>
        /// Parses a Multi Url Picker property into a list of
        /// nodes. 
        /// </summary>
        /// <param name="node">Node to read property from</param>
        /// <param name="propertyName">Property alias</param>
        /// <returns>List of nodes</returns>
        public static IEnumerable<Node> GetMultiUrlPickerNodes(this Node node, string propertyName)
        {
            if (node == null) return new List<Node>();

            var pickerState = MultiUrlPickerState.Deserialize(node.GetProperty<string>(propertyName));

            if (pickerState == null || pickerState.Items == null || !pickerState.Items.Any()) return new List<Node>();

            return pickerState.Items
                .Where(x => x.NodeId.HasValue) //Grab only the links that have a valid node id
                .Select(x => uQuery.GetNode(x.NodeId.Value)) //Select the nodes by node id
                .ToList();
        }

        /// <summary>
        /// Method to get an Umbraco Image from the given node with the provided alias
        /// </summary>
        /// <param name="n">Node context</param>
        /// <param name="alias">Alias for the image property</param>
        /// <returns>Umbraco Image representing Umbraco Media item</returns>
        public static UmbracoImage GetImage(this Node n, string alias)
        {
            return new UmbracoImage(alias, n);
        }


        /// <summary>
        /// Looks for a set property recursively up the content tree until it finds it
        /// </summary>
        /// <typeparam name="T">Return type expected</typeparam>
        /// <param name="n">Node to start searching on</param>
        /// <param name="propertyAlias">Property alias used to fetch property value</param>
        /// <returns>Property or type default</returns>
        public static T GetPropertyRecursive<T>(this Node n, string propertyAlias)
        {
            if (n == null) return default(T);
            n = n.GetAncestorOrSelfNodes()
                .FirstOrDefault(x =>
                {
                    var property = x.GetProperty(propertyAlias);
                    return property != null && property.Value.IsSet();
                });

            return n != null ? n.GetProperty<T>(propertyAlias) : default(T);
        }

        /// <summary>
        /// Gets a property value or uses the default value provided.
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="n">Node to read property from</param>
        /// <param name="propertyAlias">String alias of property</param>
        /// <param name="defaultValue">Default value to return</param>
        /// <returns>property value if found</returns>
        public static T GetPropertyOrDefault<T>(this Node n, string propertyAlias, T defaultValue, bool recursive = false)
        {
            if (n == null) return defaultValue;
            var valueSet = n.GetProperty<string>(propertyAlias).IsSet();
            return valueSet ? 
                n.GetProperty<T>(propertyAlias) : recursive ?
                n.GetPropertyRecursive<T>(propertyAlias) : defaultValue;
        }

        /// <summary>
        /// Recursively looks for a multi url picker state that has objects set
        /// </summary>
        /// <param name="n">Node to start search on</param>
        /// <param name="propertyAlias">Alias of link map</param>
        /// <returns>State object</returns>
        public static MultiUrlPickerState GetMultiUrlPickerRecursive(this Node n, string propertyAlias)
        {
            if (n == null) return new MultiUrlPickerState();
            foreach(var node in n.GetAncestorOrSelfNodes())
            {
                var property = node.GetProperty<string>(propertyAlias);
                if (!property.IsSet()) continue;

                var picker = MultiUrlPickerState.Deserialize(property);
                if (picker != null && picker.Items.Any()) return picker;
            }

            return new MultiUrlPickerState();
        }

    }
}