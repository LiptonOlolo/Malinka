using Malinka.Models;
using Malinka.Properties;
using Prism.Events;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;

namespace Malinka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Hotkey command.
        /// </summary>
        public static RoutedCommand HotkeyCommand { get; } = new RoutedCommand();

        /// <summary>
        /// Hotkey handler.
        /// </summary>
        void HotkeyExecute(object sender, ExecutedRoutedEventArgs e)
        {
            hotkeyEvent.Publish();
        }

        /// <summary>
        /// Region manager.
        /// </summary>
        readonly IRegionManager regionManager;

        /// <summary>
        /// Hotkey event.
        /// </summary>
        readonly PubSubEvent hotkeyEvent;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow(IRegionManager regionManager, PubSubEvent hotkeyEvent)
        {
            InitializeComponent();

            this.regionManager = regionManager;
            this.hotkeyEvent = hotkeyEvent;

            var settings = Settings.Default;
            if (settings.lastUser == null)
                settings.lastUser = new LoginUser();

            Left = settings.left;
            Top = settings.top;
            Width = settings.width;
            Height = settings.height;

            if (settings.state == WindowState.Minimized)
                settings.state = WindowState.Normal;

            WindowState = settings.state;

            HotkeyCommand.InputGestures.Add(new KeyGesture(Key.Escape));
        }

        /// <summary>
        /// Window is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var settings = Settings.Default;
            settings.left = Left;
            settings.top = Top;
            settings.width = Width;
            settings.height = Height;
            settings.state = WindowState;

            settings.Save();
        }

        /// <summary>
        /// Window is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            regionManager.RequestNavigateInRootRegion(RegionViews.ConnectionView);
        }
    }
}
