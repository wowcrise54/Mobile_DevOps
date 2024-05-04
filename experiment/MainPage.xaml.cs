using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace experiment
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private async void OnMainTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnLikeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Favourites());
        }

        private async void OnCelebrateTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Holidays());
        }

        private async void OnMyRecipesTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Myrecipes());
        }

        private async void OnSettingsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
    }
}
