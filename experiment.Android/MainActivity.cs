using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.View;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using experiment.Helpers;
using Android.Widget;



[assembly: Dependency(typeof(experiment.Droid.MainActivity.Environment))]


namespace experiment.Droid
{
    [Activity(Label = "experiment", Icon = "@mipmap/iconour", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       public class Environment: InterFace
        {
            public async void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
            {
                if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                    return;

                var activity = Platform.CurrentActivity;
                var window = activity.Window;

                //this may not be necessary(but may be fore older than M)
                window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
                window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);


                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                {
                    await Task.Delay(50);
                    WindowCompat.GetInsetsController(window, window.DecorView).AppearanceLightStatusBars = darkStatusBarTint;
                }

                window.SetStatusBarColor(color.ToPlatformColor());
            }
        }

    }
}