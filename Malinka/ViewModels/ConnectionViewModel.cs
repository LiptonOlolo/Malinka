using Malinka.API.Client.Interfaces;
using MaterialDesignXaml.DialogsHelper;
using Prism.Regions;

namespace Malinka.ViewModels
{
    /// <summary>
    /// Connection view model.
    /// </summary>
    class ConnectionViewModel
    {
        /// <summary>
        /// Malinka client.
        /// </summary>
        readonly IMalinkaClient malinkaClient;

        /// <summary>
        /// Region manager.
        /// </summary>
        readonly IRegionManager regionManager;

        /// <summary>
        /// Ctor.
        /// </summary>
        public ConnectionViewModel(IMalinkaClient malinkaClient, IRegionManager regionManager)
        {
            this.malinkaClient = malinkaClient;
            this.regionManager = regionManager;

            malinkaClient.Disconnected += MalinkaClient_Disconnected;
            malinkaClient.Connected += MalinkaClient_Connected;

            malinkaClient.ConnectAsync();
        }

        /// <summary>
        /// Client was connected to server.
        /// </summary>
        private void MalinkaClient_Connected()
        {
            Logger.Log.Info("Connected to server");

            NavigationParameters keys = new NavigationParameters();
            keys.Add("fromConnection", null);
            regionManager.RequestNavigateInRootRegion(RegionViews.LoginView, keys);
        }

        /// <summary>
        /// Client was disconnected from server.
        /// </summary>
        private void MalinkaClient_Disconnected()
        {
            Logger.Log.Warn("Disconnected from server");

            DialogHelper.CloseAll();

            regionManager.RequestNavigateInRootRegion(RegionViews.ConnectionView);

            malinkaClient.ConnectAsync();
        }
    }
}
