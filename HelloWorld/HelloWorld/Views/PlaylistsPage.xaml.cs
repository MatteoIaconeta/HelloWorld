using HelloWorld.Models;
using HelloWorld.ViewModels;
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
		public PlaylistPage ()
		{
			InitializeComponent ();
            BindingContext = new PlaylistsViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void OnAddPlaylist(object sender, EventArgs e)
        {
            (BindingContext as PlaylistsViewModel).AddPlaylist();
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as PlaylistsViewModel).SelectPlaylist(e.SelectedItem as PlaylistViewModel);
        }
    }
}