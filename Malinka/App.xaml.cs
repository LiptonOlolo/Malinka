using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.API.Providers;
using Malinka.Client;
using Malinka.Client.Design;
using Malinka.Dialogs;
using Malinka.Dialogs.Manager;
using Malinka.Dialogs.Settings;
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
            var culture = new CultureInfo(Settings.Default.lang);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

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
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //sync taskfactory
            containerRegistry.RegisterDelegate<TaskFactory>(x => new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext()), Reuse.Singleton);

            //dialog identifier
            containerRegistry.RegisterDelegate<IDialogIdentifier>(x => new DialogIdentifier("rootdialog"), Reuse.Singleton, "rootdialog");

            //events
            containerRegistry.RegisterSingleton<PubSubEvent>();

            //views
            containerRegistry.RegisterSingleton<MainView>();

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

            //navigation views
            containerRegistry.RegisterForNavigation<ConnectionView>();
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<MainView>();
        }
    }
}
