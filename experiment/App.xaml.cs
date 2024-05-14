using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            TheTheme.SetTheme();
        }
        protected override void OnStart()
        {
            OnResume();
            var savedLanguage = Preferences.Get("AppLanguage", "English");
            CultureInfo culture;

            if (savedLanguage == "Русский")
            {
                culture = new CultureInfo("ru");
            }
            else if (savedLanguage == "Deutsch")
            {
                culture = new CultureInfo("de");
            }
            else
            {
                culture = new CultureInfo("en");
            }

            LocalizationResourceManager.Instance.SetCulture(culture);
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
