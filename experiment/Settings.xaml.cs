using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            UpdateText();

            MessagingCenter.Subscribe<LocalizationResourceManager>(this, "CultureChanged", (sender) =>
            {
                UpdateText();
            });
        }

        private void UpdateText()
        {
            /*homeTitleLabel.Text = LocalizationResourceManager.Instance["HomeTitle"];*/
            
            Theme.Text = LocalizationResourceManager.Instance["Theme"];
            Light.Text = LocalizationResourceManager.Instance["Light"];
            Dark.Text = LocalizationResourceManager.Instance["Dark"];
            System.Text = LocalizationResourceManager.Instance["System"];
            Interfacelanguage.Text = LocalizationResourceManager.Instance["Interfacelanguage"];


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
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedLanguage = picker.SelectedItem.ToString();

            CultureInfo culture;
            if (selectedLanguage == "Русский")
            {
                culture = new CultureInfo("ru");
            }
            else if (selectedLanguage == "Deutsch")
            {
                culture = new CultureInfo("de");
            }
            else
            {
                culture = new CultureInfo("en");
            }

            LocalizationResourceManager.Instance.SetCulture(culture);

            // Сохранить выбранный язык
            Preferences.Set("AppLanguage", selectedLanguage);
        }
    }
    
}