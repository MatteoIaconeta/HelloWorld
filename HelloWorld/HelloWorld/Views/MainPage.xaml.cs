using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
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

            //Resources = new ResourceDictionary();
            //Resources["borderRadius"] = 20;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var rand = new Random();
            Resources["buttonBackgroundColor"] = Color.FromRgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
    }
}