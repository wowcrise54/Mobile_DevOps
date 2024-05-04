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

        private async void MainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}