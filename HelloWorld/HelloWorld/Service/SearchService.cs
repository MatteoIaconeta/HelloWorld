using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HelloWorld.Service
{
    public class SearchService
    {
        private List<Search> searches = new List<Search>
        {
            new Search
            {
                Id = 1,
                Location = "West Hollywood, CA, United States",
                CheckIn = new DateTime(2016, 9, 1),
                CheckOut = new DateTime(2016, 11, 1)
            },
            new Search
            {
                Id = 2,
                Location = "Santa Monica, CA, United States",
                CheckIn = new DateTime(2016, 9, 1),
                CheckOut = new DateTime(2016, 11, 1)
            }
        };

        public IEnumerable<Search> GetSearches(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return searches;

            return searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            searches.Remove(searches.Single(s => s.Id == searchId));
        }
    }
}
