using Malinka.Properties;
using MaterialDesignThemes.Wpf;

namespace Malinka.Helpers
{
    static class ThemeHelper
    {
        public static void SetTheme(bool themeIsDark)
        {
            Settings.Default.MainWindowSettings.ThemeIsDark = themeIsDark;
            Settings.Default.Save();

            PaletteHelper _paletteHelper = new PaletteHelper();
            ITheme theme = _paletteHelper.GetTheme();
            IBaseTheme baseTheme = themeIsDark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);

            Logger.Log.Info($"Set dark theme: {themeIsDark}");
        }
    }
}
