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
	public partial class ImageExercise : ContentPage
	{
        private readonly int Max = 1084;
        private readonly static int Min = 1;
        private static int id = Min;

        public ImageExercise ()
		{
			InitializeComponent ();

            LoadImage();
		}

        private void LoadImage()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri(string.Format("https://i.picsum.photos/id/{0}/1920/1080.jpg", id)),
                CachingEnabled = false
            };
        }

        private void Previous_Clicked(object sender, EventArgs e)
        {
            id = --id == Min-1 ? Max : id;
            LoadImage();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            id = ++id == Max+1 ? Min : id;
            LoadImage();
        }
    }
}