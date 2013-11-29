using System.Collections.Generic;
using System.Linq;
using KendoHelpersSampleApp.Models;
using KendoHelpersSampleApp.ViewModels;

namespace KendoHelpersSampleApp.QueryObjects
{
    public static class PeopleExtensions
    {
        private static readonly IDictionary<string, string[]> sortMappings;
        private static readonly IDictionary<string, string[]> groupMappings;
        private static readonly IDictionary<string, string> filterMappings;

        static PeopleExtensions()
        {
            sortMappings = new Dictionary<string, string[]>()
            {
                {"FullName", new []{"LastName", "FirstName"}}
            };

            groupMappings = new Dictionary<string, string[]>()
            {
                {"FullName", new []{"LastName"}}
            };

            filterMappings = new Dictionary<string, string>()
            {
                {"FullName", "LastName"}
            };
        }

        public static IEnumerable<IndexViewModel> FindAllPeople(this DataContext dataContext)
        {
            return dataContext.People.Select(person => new IndexViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            });
        }

        public static IDictionary<string, string[]> SortMappings { get { return sortMappings; } }

        public static IDictionary<string, string[]> GroupMappings { get { return groupMappings; } }

        public static IDictionary<string, string> FilterMappings { get { return filterMappings; } }
    }
}