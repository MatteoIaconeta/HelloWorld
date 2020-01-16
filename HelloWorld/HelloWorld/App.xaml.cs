using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new GreetPage();
            //MainPage = new QuotesPage();
            //MainPage = new StackPage();
            //MainPage = new StackLayoutExercise1();
            //MainPage = new StackLayoutExercise2();
            //MainPage = new GridPage();
            //MainPage = new GridExercise1();
            //MainPage = new GridExercise2();
            //MainPage = new AbsolutePage();
            //MainPage = new AbsoluteExercise1();
            //MainPage = new AbsoluteExercise2();
            //MainPage = new RelativePage();
            //MainPage = new RelativeExercise();
            //MainPage = new ImagePage();
            //MainPage = new Demo();
            //MainPage = new ImageExercise();
            //MainPage = new ListExercise();
            //MainPage = new NavigationPage(new WelcomePage())
            //{
            //    BarBackgroundColor = Color.Gray,
            //    BarTextColor = Color.White
            //};
            MainPage = new NavigationPage(new ContactsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
