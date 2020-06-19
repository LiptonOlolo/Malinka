using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.API.Providers;
using Malinka.Client;
using Malinka.Client.Design;
using Malinka.Controls.ChatLeftMenu;
using Malinka.Core.Models;
using Malinka.Dialogs;
using Malinka.Dialogs.Manager;
using Malinka.Dialogs.Settings;
using Malinka.Helpers;
using Malinka.Properties;
using Malinka.ViewModels;
using Malinka.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignXaml.DialogsHelper;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Malinka
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SettingsHelper.HandleSettigns();

            var culture = new CultureInfo(Settings.Default.lang.ShortName);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            ThemeHelper.SetTheme(Settings.Default.MainWindowSettings.ThemeIsDark);

            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<ConnectionView, ConnectionViewModel>();
            ViewModelLocationProvider.Register<LoginView, LoginViewModel>();
            ViewModelLocationProvider.Register<MainView, MainViewModel>();
            ViewModelLocationProvider.Register<MainMenu, MainMenuViewModel>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //sync taskfactory
            containerRegistry.RegisterDelegate<TaskFactory>(x => new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext()), Reuse.Singleton);

            //dialog identifier
            containerRegistry.RegisterDelegate<IDialogIdentifier>(x => new DialogIdentifier("rootdialog"), Reuse.Singleton, "rootdialog");

            //current user
            containerRegistry.RegisterSingleton<MalinkaUser>();

            //menu status
            containerRegistry.RegisterSingleton<MainMenuStatus>();

            //events
            containerRegistry.RegisterSingleton<PubSubEvent>();

            //message queue
            containerRegistry.RegisterSingleton<ISnackbarMessageQueue, SnackbarMessageQueue>();

            //client
            containerRegistry.RegisterSingleton<ISignIn, DesignSignIn>();
            containerRegistry.RegisterSingleton<ISignUp, DesignSignUp>();
            containerRegistry.RegisterSingleton<IContacts, DesignContacts>();
            containerRegistry.RegisterSingleton<IMessages, DesignMessages>();
            containerRegistry.RegisterSingleton<IMalinkaClient, DesignClient>();

            //providers
            containerRegistry.RegisterSingleton<IContactsProvider, ContactsProvider>();

            //dialog manager
            containerRegistry.RegisterSingleton<IDialogManager, DialogManager>();
            containerRegistry.RegisterSingleton<IDialogViewFactory, DialogViewFactory>();

            //dialog views
            containerRegistry.RegisterDialogView<SignUpView, SignUpViewModel>();
            containerRegistry.RegisterDialogView<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterDialogView<LanguageSelectorView, LanguageSelectorViewModel>();

            //navigation views
            containerRegistry.RegisterForNavigation<ConnectionView>();
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<MainView>();
        }
    }
}
