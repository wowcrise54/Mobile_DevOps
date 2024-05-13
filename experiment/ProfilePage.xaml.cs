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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void OnFeedBack(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        private async void OnMyRecipes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myrecipes());
        }
        private async void OnUsers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAgreement());
        }
        private async void OnPolitica(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Politica());
        }

        private async void OnStartPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
        }
    }
}