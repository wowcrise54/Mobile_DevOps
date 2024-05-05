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
     
    }
}