using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using experiment.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppPreferences))]
namespace experiment.Droid
{
    public class AppPreferences : IAppPreferences
    {
        private readonly ISharedPreferences prefs;
        private readonly ISharedPreferencesEditor editor;

        public AppPreferences()
        {
            prefs = Android.App.Application.Context.GetSharedPreferences("MyAppPreferences", FileCreationMode.Private);
            editor = prefs.Edit();
        }

        public void SavePreference(string key, int value)
        {
            editor.PutInt(key, value);
            editor.Apply();
        }

        public int GetPreference(string key, int defaultValue)
        {
            return prefs.GetInt(key, defaultValue);
        }
    }
}