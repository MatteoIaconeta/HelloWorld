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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //private void Entry_Completed(object sender, EventArgs e)
        //{
        //    label.Text = "Completed";
        //}

        //private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    label.Text = e.NewTextValue;
        //}
    }
}
