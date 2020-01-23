using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HelloWorld.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();
        private PlaylistViewModel _selectedPlaylist;
        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value); }
        }

        public void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);
            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        public void SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null)
                return;
            playlist.IsFavorite = !playlist.IsFavorite;
            SelectedPlaylist = null;

            //await Navigation.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}
