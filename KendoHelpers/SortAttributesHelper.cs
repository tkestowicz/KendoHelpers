using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc;
using Kendo.Mvc.UI;

namespace KendoHelpers
{
    public static class SortAttributesHelper
    {
        public static DataSourceRequest SortAttributesMapping(this DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            return request.SelectAttributesToReplace(mappings).ReplaceMappings(request, mappings);
        }

        private static void ApplyNewMapping(this  SortDescriptor oldMapping, DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            mappings.NewMappings(oldMapping).ToList().ForEach(newMapping => request.Sorts.Add(PrepareDescriptor(newMapping, oldMapping)));
        }

        private static DataSourceRequest ReplaceMappings(this IEnumerable<SortDescriptor> attributesToReplace, DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            attributesToReplace.ToList().ForEach(oldMapping =>
                    oldMapping.RemoveOldMapping(request).ApplyNewMapping(request, mappings)
                        );

            return request;
        }

        private static SortDescriptor RemoveOldMapping(this SortDescriptor oldMapping, DataSourceRequest request)
        {
            request.Sorts.Remove(oldMapping);

            return oldMapping;
        }

        private static SortDescriptor PrepareDescriptor(string newMapping, SortDescriptor oldMapping)
        {
            return new SortDescriptor(newMapping, oldMapping.SortDirection);
        }

        private static void RemoveOldMapping(DataSourceRequest request, SortDescriptor oldMapping)
        {
            request.Sorts.Remove(oldMapping);
        }

        private static IEnumerable<SortDescriptor> SelectAttributesToReplace(this DataSourceRequest request, IDictionary<string, string[]> mappings)
        {
            return request.Sorts.Where(sort => mappings.ContainsKey(sort.Member)).ToList();
        }

        private static IEnumerable<string> NewMappings(this IDictionary<string, string[]> mappings, SortDescriptor oldMapping)
        {
            return mappings[oldMapping.Member];
        }
    }
}