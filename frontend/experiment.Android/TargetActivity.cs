using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GR.Net.Maroulis.Library;
using System;
using System.Collections.Generic;
using Android.Graphics;
using System.Linq;
using System.Text;

namespace experiment.Droid
{
    [Activity(Label = "TargetActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class TargetActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var config = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(TargetActivity)))
                .WithSplashTimeOut(5000)
                .WithBackgroundColor(Color.ParseColor("#181818"))
                .WithLogo(Resource.Drawable.splash_screen);

            View view = config.Create();

            SetContentView(view);
        }
    }
}