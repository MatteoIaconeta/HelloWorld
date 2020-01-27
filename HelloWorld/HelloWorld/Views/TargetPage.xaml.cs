using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TargetPage : ContentPage
	{
        //public event EventHandler<double> SliderValueChanged;
		public TargetPage ()
		{
			InitializeComponent ();
		}

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            MessagingCenter.Send(this, "SliderValueChanged", e.NewValue);
            //SliderValueChanged?.Invoke(this, e.NewValue);
        }
    }
}