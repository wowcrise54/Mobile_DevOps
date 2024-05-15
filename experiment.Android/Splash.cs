using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace experiment.Droid
{
    [Activity(Label = "experiment", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Инициализация Xamarin.Forms
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var appPreferences = DependencyService.Get<IAppPreferences>();
            var theme = appPreferences.GetPreference("AppTheme", 0);

            switch (theme)
            {
                case 1: // Light Theme
                    SetTheme(Resource.Style.My_Thema_Splash_Light);
                    break;
                case 2: // Dark Theme
                    SetTheme(Resource.Style.My_Thema_Splash);
                    break;
                default: // System or other theme
                    if ((Resources.Configuration.UiMode & UiMode.NightMask) == UiMode.NightYes)
                    {
                        SetTheme(Resource.Style.My_Thema_Splash);
                    }
                    else
                    {
                        SetTheme(Resource.Style.My_Thema_Splash_Light);
                    }
                    break;
            }
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await SimulateStartup();
        }

        async Task SimulateStartup()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            StartActivity(new Intent(Android.App.Application.Context, typeof(MainActivity)));
            Finish();
        }

    }
}
