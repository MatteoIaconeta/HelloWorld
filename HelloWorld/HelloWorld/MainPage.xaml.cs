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

    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        private IList<ContactMethod> contactMethods;
        public MainPage()
        {
            InitializeComponent();

            contactMethods = GetContactMethods();

            foreach (var method in contactMethods)
                picker.Items.Add(method.Name);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = picker.Items[picker.SelectedIndex];
            var contactMethod = contactMethods.Single(cm => cm.Name.Equals(name));

            DisplayAlert("Selection", name, "OK");
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod { Id = 1, Name = "SMS" },
                new ContactMethod { Id = 2, Name = "Email" }
            };
        }
    }
}
