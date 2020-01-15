using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HelloWorld.Models
{
    public class SearchGroups : ObservableCollection<Search>
    {
        public string Title { get; set; }

        public SearchGroups(string title, IEnumerable<Search> searches = null) : base(searches)
        {
            Title = title;
        }
    }
}
