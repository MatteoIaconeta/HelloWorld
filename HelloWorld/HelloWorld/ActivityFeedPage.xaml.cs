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
	public partial class ActivityFeedPage : ContentPage
	{
        private ActivityService activityService = new ActivityService();
		public ActivityFeedPage ()
		{
			InitializeComponent ();

            listView.ItemsSource = activityService.GetActivities();
		}

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var activity = e.SelectedItem as Activity;
            listView.SelectedItem = null;
            Navigation.PushAsync(new UserProfilePage(activity.UserId));
        }
    }
}