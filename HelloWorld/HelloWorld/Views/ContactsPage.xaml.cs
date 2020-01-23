using HelloWorld.Models;
using HelloWorld.Persistence;
using SQLite;
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
        private ObservableCollection<Contact> contacts;
        private SQLiteAsyncConnection connection;
        private bool IsDataLoaded;

		public ContactsPage ()
		{
			InitializeComponent ();

            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
		}

        protected override async void OnAppearing()
        {
            if (IsDataLoaded)
                return;
            IsDataLoaded = true;
            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await connection.CreateTableAsync<Contact>();
            contacts = new ObservableCollection<Contact>(await connection.Table<Contact>().ToListAsync());
            contactsListView.ItemsSource = contacts;
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
            if (contactsListView.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contactsListView.SelectedItem = null;

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
            {
                contacts.Remove(contact);
                await connection.DeleteAsync(contact);
            }                
        }
    }
}