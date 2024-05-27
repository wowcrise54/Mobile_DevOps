using System;
using System.Collections.Generic;
using System.Text;

namespace experiment
{
    public interface IAppPreferences
    {
        void SavePreference(string key, int value);
        int GetPreference(string key, int defaultValue);
    }
}
