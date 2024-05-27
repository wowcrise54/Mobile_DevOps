using experiment.Resources_1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace experiment
{
    public class LocalizationResourceManager
    {
        public static LocalizationResourceManager Instance { get; } = new LocalizationResourceManager();

        public void SetCulture(CultureInfo culture)
        {
            Strings.Culture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            MessagingCenter.Send(this, "CultureChanged");
        }

        public string this[string text]
        {
            get => Strings.ResourceManager.GetString(text, Strings.Culture);
        }
    }
}
