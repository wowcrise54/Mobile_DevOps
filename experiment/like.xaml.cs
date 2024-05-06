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
    public partial class like : ContentPage
    {
        public like()
        {
            InitializeComponent();
            
        }
    
        private void OnSearchClicked(object sender, EventArgs e)
        {

            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private async void OnKabachok(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kabachok());
        }
        private async void OnGrudka(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Grudka());
        }
        private async void OnChicken(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chicken());
        }
        private async void OnSalat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Salat());
        }
    }
}