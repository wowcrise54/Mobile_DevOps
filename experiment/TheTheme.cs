﻿using System;
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

        }
    }
}
