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
	public partial class GridPage : ContentPage
	{
		public GridPage ()
		{
			InitializeComponent ();

            var grid = new Grid
            {
                RowSpacing = 40,
                ColumnSpacing = 40,
                BackgroundColor = Color.Yellow
            };

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(100, GridUnitType.Absolute)
            });

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(2, GridUnitType.Star)
            });

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(2, GridUnitType.Star)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            grid.Children.Add(new Label { Text = "Label 1", BackgroundColor = Color.Silver }, 0, 0);
            grid.Children.Add(new Label { Text = "Label 2", BackgroundColor = Color.Silver }, 0, 1);
            grid.Children.Add(new Label { Text = "Label 3", BackgroundColor = Color.Silver }, 1, 0);
            grid.Children.Add(new Label { Text = "Label 4", BackgroundColor = Color.Silver }, 1, 1);

            Content = grid;
        }
    }
}