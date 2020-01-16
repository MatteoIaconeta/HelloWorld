using HelloWorld.Models;
using HelloWorld.Services;
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
	public partial class UserProfilePage : ContentPage
	{
        private UserService userService = new UserService();
		public UserProfilePage (int userId)
		{
            BindingContext = userService.GetUser(userId) ?? throw new ArgumentNullException();
			InitializeComponent ();
		}
	}
}