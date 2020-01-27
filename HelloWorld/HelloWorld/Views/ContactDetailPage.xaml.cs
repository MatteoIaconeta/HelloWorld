using HelloWorld.Persistence;
using HelloWorld.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
    { 
        public ContactDetailPage (ContactViewModel viewModel)
		{
            InitializeComponent();

            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            BindingContext = new ContactDetailViewModel(viewModel ?? new ContactViewModel(), contactStore, pageService);
        }
    }
}