using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class settings : ContentPage
    {
        public settings()
        {
            InitializeComponent();
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void OnSearchClicked(object sender, EventArgs e)
        {

            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }
    }
}