using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaylistPage : ContentPage
	{
        private ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();
		public PlaylistPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            playlistsListView.ItemsSource = playlists;
            base.OnAppearing();
        }

        private void OnAddPlaylist(object sender, EventArgs e)
        {
            var newPlaylist = "Playlist " + (playlists.Count + 1);
            playlists.Add(new Playlist { Title = newPlaylist });
            Title = $"{playlists.Count} Playlists";
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var playlist = e.SelectedItem as Playlist;
            playlist.IsFavorite = !playlist.IsFavorite;
            playlistsListView.SelectedItem = null;

            //await Navigation.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}