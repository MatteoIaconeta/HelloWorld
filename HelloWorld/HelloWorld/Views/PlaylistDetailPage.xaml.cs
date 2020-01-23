using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaylistDetailPage : ContentPage
	{
        private Playlist _playlist;
		public PlaylistDetailPage (Playlist playlist)
		{
            InitializeComponent ();

            _playlist = playlist;
            title.Text = _playlist.Title;
		}
	}
}