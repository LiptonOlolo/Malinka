using Malinka.Lang;
using Malinka.Models;
using Malinka.Properties;
using System.Windows;

namespace Malinka.Helpers
{
    static class SettingsHelper
    {
        public static void HandleSettigns()
        {
            var settings = Settings.Default;
            if (settings.lastUser == null)
                settings.lastUser = new LoginUser();

            if (settings.lang == null)
                settings.lang = Languages.Default;

            if (settings.MainWindowSettings == null)
                settings.MainWindowSettings = new WindowSettings();
            else if (settings.MainWindowSettings.State == WindowState.Minimized)
                settings.MainWindowSettings.State = WindowState.Normal;
        }
    }
}
