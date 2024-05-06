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
            await Navigation.PushAsync(new like());
        }
        private async void OnMyRecipes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myrecipes());
        }
    }
}