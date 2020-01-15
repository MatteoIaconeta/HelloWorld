using HelloWorld.Models;
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
	public partial class Demo : ContentPage
	{
		public Demo ()
		{
			InitializeComponent ();

            listView.ItemsSource = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://i.picsum.photos/id/1/100/100.jpg"},
                new Contact { Name = "John", ImageUrl = "https://i.picsum.photos/id/2/100/100.jpg", Status = "Hey, let's talk" }                
            };
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "OK");
            //listView.SelectedItem = null;
        }
    }
}