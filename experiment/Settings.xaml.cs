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
    public partial class settings : ContentPage
    {
        

        public settings()
        {
            InitializeComponent();
            switch (Sett1.Theme)
            {
                case 0:
                    RadioButtonSystem.IsChecked = true;
                    break;
                case 1:
                    RadioButtonLight.IsChecked = true;
                    break;
                case 2:
                    RadioButtonDark.IsChecked = true;
                    break;
            }
        }
        bool loaded;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loaded = true;
        }
        void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!loaded)
                return;

            if (!e.Value)
                return;

            var val = (sender as RadioButton)?.Value as string;
            if (string.IsNullOrWhiteSpace(val))
                return;

            switch (val)
            {
                case "System":
                    Sett1.Theme = 0;
                    break;
                case "Light":
                    Sett1.Theme = 1;
                    break;
                case "Dark":
                    Sett1.Theme = 2;
                    break;
            }

            TheTheme.SetTheme();
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void OnSearchClicked(object sender, EventArgs e)
        {

            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }
        private void ThemeSwitch_Toggled(object sender, EventArgs e)
        {

            DisplayAlert("Alert", "Edit button clicked!", "OK");
        }

    }
    
}