using DevExpress.Mvvm;
using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.Core.Models;
using Malinka.Dialogs.Manager;
using Malinka.Models;
using Malinka.Properties;
using Malinka.ViewModels.Base;
using MaterialDesignXaml.DialogsHelper;
using MaterialDesignXaml.DialogsHelper.Enums;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Malinka.ViewModels
{
    /// <summary>
    /// Login view model.
    /// </summary>
    class LoginViewModel : NavigationViewModel
    {
        /// <summary>
        /// User for login.
        /// </summary>
        public LoginUser LoginUser => settings.lastUser;

        /// <summary>
        /// Remember Me (auto login).
        /// </summary>
        public bool RememberMe
        {
            get => settings.rememberMe;
            set => settings.rememberMe = value;
        }

        /// <summary>
        /// Project settings.
        /// </summary>
        readonly Settings settings;

        /// <summary>
        /// Dialog identifier.
        /// </summary>
        readonly IDialogIdentifier dialogIdentifier;

        /// <summary>
        /// Sign in.
        /// </summary>
        readonly ISignIn signIn;

        /// <summary>
        /// Region manager.
        /// </summary>
        readonly IRegionManager regionManager;

        /// <summary>
        /// Ctor for design.
        /// </summary>
        public LoginViewModel()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public LoginViewModel(IRegionManager regionManager,
                              IDialogManager dialogManager,
                              ISignIn signIn,
                              MalinkaUser user,
                              IContainer container) : base(user)
        {
            settings = Settings.Default;
            dialogIdentifier = container.ResolveRootDialogIdentifier();
            this.signIn = signIn;
            this.regionManager = regionManager;

            SignInCommand = new AsyncCommand(SignIn, () => settings.lastUser.IsValid);
            SignUpCommand = new DelegateCommand(dialogManager.ShowSignUpAsync);
            ShowLanguageSelectorCommand = new DelegateCommand(() => dialogManager.ShowLanguageSelector(dialogIdentifier));
        }

        /// <summary>
        /// Sign in command.
        /// </summary>
        public ICommand SignInCommand { get; }

        /// <summary>
        /// Set English command.
        /// </summary>
        public ICommand ShowLanguageSelectorCommand { get; }

        /// <summary>
        /// Sign up command.
        /// </summary>
        public ICommand SignUpCommand { get; }

        /// <summary>
        /// Sign in.
        /// </summary>
        /// <returns></returns>
        private async Task SignIn()
        {
            var res = await signIn.SignInAsync(settings.lastUser.EMail, settings.lastUser.Password);

            if (!res)
            {
                Logger.Log.Error($"Sign In error: {res.Code}");
                await dialogIdentifier.ShowMessageBoxAsync(res.ToString(), MaterialMessageBoxButtons.Ok);
            }
            else if (!res.Argument)
            {
                Logger.Log.Warn($"Unsuccessful logged in, arg: {res.Argument}");
                await dialogIdentifier.ShowMessageBoxAsync(res.Argument.ToString(), MaterialMessageBoxButtons.Ok);
            }
            else
            {
                Logger.Log.Info("Successful logged in");
                regionManager.RequestNavigateInRootRegion(RegionViews.MainView, RegionHelper.GetParamsWithUser(res.Result));
            }
        }

        /// <summary>
        /// Navigated to.
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("fromConnection") && RememberMe)
            {
                SignInCommand.Execute(null);
            }
        }
    }
}
