using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace experiment
{
    public static class Sett1
    {
        // 0 = default, 1 = light, 2 = dark
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
