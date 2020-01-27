using HelloWorld.Models;
using HelloWorld.Views;
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
        }

        private void OnClick(object sender, EventArgs e)
        {
            var page = new TargetPage();
            //page.SliderValueChanged += OnSliderValueChanged;
            MessagingCenter.Subscribe<TargetPage, double>(this, Events.SliderValueChanged, OnSliderValueChanged);
            Navigation.PushAsync(page);
            MessagingCenter.Unsubscribe<MainPage>(this, Events.SliderValueChanged);
        }

        private void OnSliderValueChanged(TargetPage source, double newValue)
        {
            label.Text = newValue.ToString();
        }
    }
}