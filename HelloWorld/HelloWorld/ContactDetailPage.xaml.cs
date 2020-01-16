using HelloWorld.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
	{
		public ContactDetailPage (Contact contact)
		{
            BindingContext = contact ?? throw new ArgumentNullException();

			InitializeComponent ();
		}
	}
}