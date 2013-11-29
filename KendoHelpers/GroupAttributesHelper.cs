using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebGrease.Css.Extensions;

namespace KendoHelpers
{
    public static class GroupAttributesHelper
    {
        public static DataSourceRequest GroupAttributesMapping(this DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            return request.SelectAttributesToReplace(mappings).ReplaceMappings(request, mappings);
        }

        private static DataSourceRequest ReplaceMappings(this IEnumerable<GroupDescriptor> attributesToReplace, DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            attributesToReplace.ForEach(oldMapping =>
                    oldMapping.RemoveOldMapping(request).ApplyNewMapping(request, mappings)
                        );

            return request;
        }


        private static void ApplyNewMapping(this GroupDescriptor oldMapping, DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            mappings.NewMappings(oldMapping).ForEach(newMapping => request.Groups.Add(PrepareDescriptor(newMapping, oldMapping)));
        }

        private static GroupDescriptor PrepareDescriptor(string newMapping, GroupDescriptor oldMapping)
        {
            var obj = new GroupDescriptor()
            {
                Member = newMapping,
                SortDirection = oldMapping.SortDirection,
                DisplayContent = oldMapping.DisplayContent
            };

            obj.AggregateFunctions.AddRange(oldMapping.AggregateFunctions);

            return obj;
        }

        private static GroupDescriptor RemoveOldMapping(this GroupDescriptor oldMapping, DataSourceRequest request)
        {
            request.Groups.Remove(oldMapping);

            return oldMapping;
        }

        private static IEnumerable<GroupDescriptor> SelectAttributesToReplace(this DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            return request.Groups.Where(group => mappings.ContainsKey(group.Member)).ToList();
        }

        private static IEnumerable<string> NewMappings(this IDictionary<string, string[]> mappings, GroupDescriptor oldMapping)
        {
            return mappings[oldMapping.Member];
        }
    }
}