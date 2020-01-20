using HelloWorld.Extensions;
using HelloWorld.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
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
