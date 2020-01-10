using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuotesPage : ContentPage
	{
        private int index = 0;
        private string[] quotes = new string[]
        {
            "Life is like riding a bicycle. To keep your balance, you must keep moving.",
            "You can't blame gravity for falling in love.",
            "Look deep into nature, and then you will understand everything better."
        };

		public QuotesPage ()
		{
			InitializeComponent ();
            currentQuote.Text = quotes[index];
		}

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            index = ++index >= quotes.Length ? 0 : index;
            currentQuote.Text = quotes[index];
        }
    }
}