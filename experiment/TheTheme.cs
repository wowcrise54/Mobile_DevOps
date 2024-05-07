using experiment.Helpers;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace experiment
{
    public static class TheTheme
    {
        public static void SetTheme()
        {
            switch (Sett1.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
            var myCustomColor = Color.FromHex("#D499A0");
            var e = DependencyService.Get<InterFace>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Color.Black, false);
             
            }
            else
            {
                e?.SetStatusBarColor(myCustomColor, true);
              
            }
        }
    }
}
