using Malinka.Core.Models;
using Prism.Regions;

namespace Malinka
{
    static class RegionViews
    {
        public const string LoginView = nameof(Views.LoginView);
        public const string ConnectionView = nameof(Views.ConnectionView);
        public const string MainView = nameof(Views.MainView);
    }

    static class RegionNames
    {
        public const string RootRegion = nameof(RootRegion);
    }

    static class RegionHelper
    {
        public static NavigationParameters GetParamsWithUser(MalinkaUser user)
        {
            NavigationParameters @params = new NavigationParameters();
            @params.Add("user", user);

            return @params;
        }

        public static void RequestNavigateInRootRegion(this IRegionManager regionManager, string view, NavigationParameters parameters = null)
        {
            regionManager.RequestNavigate(RegionNames.RootRegion, view, parameters);
        }
    }
}
