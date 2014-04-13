using MetroBlooms.ViewModels.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;
using umbraco;

namespace MetroBlooms.Utilities
{
    /// <summary>
    /// Factory used to return section objects
    /// </summary>
    public static class SectionFactory
    {
        private static Dictionary<string, Type> AliasTypeMap { get; set; }
        /// <summary>
        /// On application start, find all of the section nodes in the CMS
        /// by naming convention (starts with "Section - "). For each one, use
        /// reflection to find the corresponding type to instantiate to display
        /// a section. 
        /// </summary>
        static SectionFactory()
        {
            AliasTypeMap = uQuery.GetNode(-1)
                .GetDescendantNodes()
                .Where(node => node.NodeTypeAlias.StartsWith("Section-"))
                .Select(node => node.NodeTypeAlias).Distinct()
                .ToDictionary(alias => alias, alias => FetchTypeFromNodeAlias(alias));
        }
        /// <summary>
        /// Will instantiate an instance of the correct class based on
        /// the provided node. Uses the nodeTypeAlias from the provided
        /// node and finds the corresponding type from the AliasTypeMap dictionary
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static BaseSection FetchSectionByNode(Node node)
        {
            return AliasTypeMap.ContainsKey(node.NodeTypeAlias) ?
                (BaseSection)Activator.CreateInstance(AliasTypeMap[node.NodeTypeAlias], node) as BaseSection :
                new BaseSection(node);
        }
        /// <summary>
        /// Given a node, this will fetch the corresponding type to return
        /// using reflection and a specific naming convention.
        /// Naming Convention:
        /// Node Alias = "Section-[Section Name]"
        /// Class Name = "[Section Name]Section"
        /// The section classes have to belong to the same namespace as BaseSection
        /// </summary>
        /// <param name="node">Node to render section from</param>
        /// <returns>Type used to instantiate class from</returns>
        private static Type FetchTypeFromNodeAlias(string nodeAlias)
        {
            var className = nodeAlias.Replace("Section-", "") + "Section";
            return Type.GetType(typeof(BaseSection).Namespace + "." + className);
        }
    }
}