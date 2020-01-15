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

            listView.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup("M", "M")
                {
                    new Contact { Name = "Mosh", ImageUrl = "https://i.picsum.photos/id/1/100/100.jpg"},
                },
                new ContactGroup("J", "J")
                {
                    new Contact { Name = "John", ImageUrl = "https://i.picsum.photos/id/2/100/100.jpg", Status = "Hey, let's talk" }
                }                
            };
		}
	}
}