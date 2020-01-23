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
	public partial class AbsolutePage : ContentPage
	{
		public AbsolutePage ()
		{
			InitializeComponent ();

            var layout = new AbsoluteLayout();

            layout.Children.Add(new BoxView { Color = Color.Aqua }, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(new BoxView { Color = Color.White }, new Rectangle(0.5, 0.1, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            layout.Children.Add(new Button { Text = "Get Started", BackgroundColor = Color.Silver, TextColor = Color.White }, new Rectangle(0, 1, 1, 50), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            Content = layout;
        }
	}
}