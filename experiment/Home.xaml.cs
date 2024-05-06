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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        

        private async void OnImageTapped(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new More());
        }
        private async void OnImageTapped_1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new More_2());
        }
        private async void OnImageTapped_2(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new More_3());
        }
        private async void ProfileButton(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ProfilePage());
        }

        private async void OnHearts(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Hearts());
        }

        private async void OnRecipe(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new recipe());
        }
        private async void OnIzume(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new izume());
        }

        private async void OnFastfood(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Fastfood());
        }

        private async void OnFood(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Food());
        }

        private async void OnZozh(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Zozh());
        }
        private async void Frame_Tapped(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Humus());
        }
        private async void Frame_Tapped_1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Sup());
        }
        private async void Frame_Tapped_2(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Kotleta());
        }
        private async void Frame_Tapped_3(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Pirog());
        }
        private async void Frame_Tapped_4(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Pravilnoe_pitanie());
        }


        private void OnSearchClicked(object sender, EventArgs e)
        {
            
            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }

    }
}