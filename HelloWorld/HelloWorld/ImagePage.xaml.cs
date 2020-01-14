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

            //btn.ImageSource = ImageSource.FromFile("clock.png");
            var imageSource = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    imageSource = "clock.png";
                    break;
                case Device.Android:
                    imageSource = "clock.png";
                    break;
                case Device.UWP:
                    imageSource = "Images/clock.png";
                    break;
            }
            btn.ImageSource = ImageSource.FromFile(imageSource);
		}
	}
}