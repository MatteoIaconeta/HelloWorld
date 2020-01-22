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

    public class Post : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _title;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Body { get; set; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class MainPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient client = new HttpClient();
        private ObservableCollection<Post> posts;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await client.GetStringAsync(Url);
            posts = new ObservableCollection<Post>(JsonConvert.DeserializeObject<List<Post>>(content));
            postsListView.ItemsSource = posts;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var post = new Post { Title = "Title " + DateTime.Now.Ticks };
            posts.Insert(0, post);
            var content = JsonConvert.SerializeObject(post);
            await client.PostAsync(Url, new StringContent(content));
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            var post = posts[0];
            post.Title += " UPDATED";
            var content = JsonConvert.SerializeObject(post);
            await client.PutAsync(Url + "/" + post.Id, new StringContent(content));
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var post = posts[0];
            posts.Remove(post);
            await client.DeleteAsync(Url + "/" + post.Id);
        }
    }
}