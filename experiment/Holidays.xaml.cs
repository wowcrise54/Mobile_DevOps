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
	public partial class Holidays : ContentPage
	{
		public Holidays ()
		{
			InitializeComponent ();
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