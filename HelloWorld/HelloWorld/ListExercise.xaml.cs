using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListExercise : ContentPage
	{
        private SearchService searchService;
        private List<SearchGroups> searchGroups;
		public ListExercise ()
		{
			InitializeComponent ();

            searchService = new SearchService();                            
            PopulateListView(searchService.GetSearches());
		}

        private void PopulateListView(IEnumerable<Search> searches)
        {
            searchGroups = new List<SearchGroups>
            {
                new SearchGroups("Recent Searches", searches)
            };
            listView.ItemsSource = searchGroups;
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(searchService.GetSearches(e.NewTextValue));
        }

        private void OnRefreshing(object sender, EventArgs e)
        {
            PopulateListView(searchService.GetSearches(searchBar.Text));
            listView.EndRefresh();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;
            searchGroups[0].Remove(search);
            searchService.DeleteSearch(search.Id);
        }

        private void OnSearchSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}