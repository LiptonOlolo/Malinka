using DevExpress.Mvvm;
using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.Client.Design;
using Malinka.Core.Models;
using Malinka.Dialogs.Manager;
using Malinka.Properties;
using Prism.Regions;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace Malinka.Controls.ChatLeftMenu
{
    /// <summary>
    /// Chat left menu view model.
    /// </summary>
    class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Current user.
        /// </summary>
        public MalinkaUser User { get; }

        /// <summary>
        /// Malinka client version.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Menu status.
        /// </summary>
        readonly MainMenuStatus menuStatus;

        /// <summary>
        /// Sign in service.
        /// </summary>
        readonly ISignIn signIn;

        /// <summary>
        /// Region manager.
        /// </summary>
        readonly IRegionManager regionManager;

        /// <summary>
        /// Dialog manager.
        /// </summary>
        readonly IDialogManager dialogManager;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public MainMenuViewModel()
        {
            User = new DesignSignIn().SignInAsync("", "").Result.Result;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainMenuViewModel(ISignIn signIn,
                                     IRegionManager regionManager,
                                     IDialogManager dialogManager,
                                     MalinkaUser user,
                                     MainMenuStatus menuStatus,
                                     IContainer container)
        {
            this.signIn = signIn;
            this.regionManager = regionManager;
            this.dialogManager = dialogManager;
            this.menuStatus = menuStatus;
            User = user;

            ShowContactsCommand = new DelegateCommand(ShowContacts);
            ShowSettingsCommand = new DelegateCommand(ShowSettings);
            LogOutCommand = new DelegateCommand(LogOut);
            OpenMalinkaDesktopCommand = new DelegateCommand(OpenMalinkaDesktop);

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            Version = fileVersionInfo.ProductVersion;
        }

        /// <summary>
        /// Show contacts command.
        /// </summary>
        public ICommand ShowContactsCommand { get; }

        /// <summary>
        /// Show settigns command.
        /// </summary>
        public ICommand ShowSettingsCommand { get; }

        /// <summary>
        /// Log out command.
        /// </summary>
        public ICommand LogOutCommand { get; }

        /// <summary>
        /// Open "Malinka Desktop" url.
        /// </summary>
        public ICommand OpenMalinkaDesktopCommand { get; }

        /// <summary>
        /// Open "Malinka Desktop" url.
        /// </summary>
        private void OpenMalinkaDesktop()
        {
            Process.Start(Settings.Default.malinkaUrl);
        }

        /// <summary>
        /// Log out.
        /// </summary>
        private void LogOut()
        {
            signIn.LogOutAsync();

            Logger.Log.Info("Log out from server");

            menuStatus.MenuOpened = false;

            regionManager.RequestNavigateInRootRegion(RegionViews.LoginView);
        }

        /// <summary>
        /// Show settings.
        /// </summary>
        private void ShowSettings()
        {
            menuStatus.MenuOpened = false;
            dialogManager.ShowSettings(User);
        }

        /// <summary>
        /// Show contacts.
        /// </summary>
        private void ShowContacts()
        {
            menuStatus.MenuOpened = false;
        }
    }
}
