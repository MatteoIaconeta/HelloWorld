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
	public partial class Demo : ContentPage
	{
        private ObservableCollection<Contact> contacts;
		public Demo ()
		{
			InitializeComponent ();

            contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://i.picsum.photos/id/1/100/100.jpg"},
                new Contact { Name = "John", ImageUrl = "https://i.picsum.photos/id/2/100/100.jpg", Status = "Hey, let's talk" }                
            };

            listView.ItemsSource = contacts;
		}

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact =  menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            contacts.Remove(contact);
        }
    }
}