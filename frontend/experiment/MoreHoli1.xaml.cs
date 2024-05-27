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
    public partial class MoreHoli1 : ContentPage
    {
        public MoreHoli1()
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
        private async void OnSalat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Salat());
        }

        private void OnClick(object sender, EventArgs e)
        {
            var image = sender as Image;
            if (image == null) return;


            if (Application.Current.UserAppTheme == OSAppTheme.Dark)
            {
                if (image.Source.ToString().Contains("dark_not_like.png"))
                    image.Source = "dark_like.png";
                else
                    image.Source = "dark_not_like.png";
            }
            else
            {
                if (image.Source.ToString().Contains("dark_not_like.png"))
                    image.Source = "dark_like.png";
                else
                    image.Source = "dark_not_like.png";
            }
        }
    }
}