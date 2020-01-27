using HelloWorld.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
    { 
        public ContactDetailPage (ContactDetailViewModel viewModel)
		{
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}