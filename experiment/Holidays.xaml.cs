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
    public partial class holidays : ContentPage
    {
        public holidays()
        {
            InitializeComponent();
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private async void OnCorzinaColors(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CorzinaColors());
        }
        private async void OnKulich(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kulichik());
        }
        private async void OnPusha(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pusha());
        }
        private async void OnMore1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoreHoli1());
        }
        private async void OnGoose(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Goose());
        }
        private async void OnOlive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Olive());
        }
        private async void OnSeld(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Seld());
        }

        private async void OnMore2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoreHoli2());
        }

        private async void OnTort(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tort());
        }
        private async void OnKurnik(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kurnik());
        }

        private async void OnTartaletki(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tartaletki());
        }
        private async void OnMore3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoreHoli3());
        }
        private void OnSearchClicked(object sender, EventArgs e)
        {

            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }
    }
}