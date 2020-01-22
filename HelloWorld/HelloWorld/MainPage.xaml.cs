using HelloWorld.Extensions;
using HelloWorld.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;
        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Name)));
                //OnPropertyChanged();
            }
        }

        //private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        //}

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }

    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection connection;
        private ObservableCollection<Recipe> recipes;
        public MainPage()
        {
            InitializeComponent();

            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await connection.CreateTableAsync<Recipe>();
            recipes = new ObservableCollection<Recipe>(await connection.Table<Recipe>().ToListAsync());
            recipesListView.ItemsSource = recipes;

            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await connection.InsertAsync(recipe);
            recipes.Add(recipe);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            var recipe = recipes[0];
            recipe.Name += " UPDATED";
            await connection.UpdateAsync(recipe);
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var recipe = recipes[0];
            await connection.DeleteAsync(recipe);
            recipes.Remove(recipe);
        }
    }
}