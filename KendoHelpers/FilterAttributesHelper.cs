using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc;
using Kendo.Mvc.UI;

namespace KendoHelpers
{
    public static class FilterAttributesHelper
    {
        public static DataSourceRequest FilterAttributesMapping(this DataSourceRequest request, IDictionary<string, string> mappings)
        {
            return request.SelectAttributesToReplace(mappings).ReplaceMappings(request, mappings);
        }

        private static DataSourceRequest ReplaceMappings(this IEnumerable<FilterDescriptor> attributesToReplace, DataSourceRequest request, IDictionary<string, string> mappings)
        {
            attributesToReplace.ToList().ForEach(oldMapping => 
                    oldMapping.RemoveOldMapping(request).ApplyNewMapping(request, mappings)
                        );

            return request;
        }

        private static void ApplyNewMapping(this FilterDescriptor oldMapping, DataSourceRequest request, IDictionary<string, string> mappings)
        {
            request.Filters.Add(PrepareDescriptor(mappings.NewMapping(oldMapping), oldMapping));
        }

        private static FilterDescriptor PrepareDescriptor(string newMapping, FilterDescriptor oldMapping)
        {
            return new FilterDescriptor()
            {
                Member = newMapping,
                Operator = oldMapping.Operator,
                Value = oldMapping.Value
            };
        }

        private static IEnumerable<FilterDescriptor> SelectAttributesToReplace(this DataSourceRequest request, IDictionary<string, string> mappings)
        {
            return request.Filters.Select(filter => filter as FilterDescriptor ?? new FilterDescriptor()).Where(filter => mappings.ContainsKey(filter.Member)).ToList();
        }

        private static FilterDescriptor RemoveOldMapping(this FilterDescriptor oldMapping, DataSourceRequest request)
        {
            request.Filters.Remove(oldMapping);

            return oldMapping;
        }

        private static string NewMapping(this IDictionary<string, string> mappings, FilterDescriptor oldMapping)
        {
            return mappings[oldMapping.Member];
        }
    }
}