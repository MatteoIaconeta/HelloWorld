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
	public partial class ContactsPage : ContentPage
	{
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>
        {
            new Contact { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@smith.com", Phone = "1111" },
            new Contact { Id = 1, FirstName = "Mary", LastName = "Johnson", Email = "mary@johnson.com", Phone = "2222" }
        };

		public ContactsPage ()
		{
			InitializeComponent ();

            listView.ItemsSource = contacts;
		}

        async private void OnAddContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());
            page.ContactAdded += (source, contact) =>
            {
                contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        async private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        async private void OnDeleteContact(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                contacts.Remove(contact);
        }
    }
}