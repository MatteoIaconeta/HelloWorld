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
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();

            //var imageSource = (UriImageSource)ImageSource.FromUri(new Uri("https://loremflickr.com/1080/1920"));
            var imageSource = new UriImageSource { Uri = new Uri("https://loremflickr.com/1080/1920") };
            imageSource.CachingEnabled = false;
            //imageSource.CacheValidity = TimeSpan.FromHours(1);

            image.Source = imageSource;            
		}
	}
}