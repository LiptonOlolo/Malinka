using DevExpress.Mvvm;
using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.Dialogs.Manager;
using Malinka.Helpers;
using Malinka.Lang.Properties;
using Malinka.Models;
using Malinka.Properties;
using Malinka.ViewModels.Base;
using MaterialDesignXaml.DialogsHelper;
using MaterialDesignXaml.DialogsHelper.Enums;
using Prism.Regions;
using System;
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
                              IContainer container)
        {
            settings = Settings.Default;
            dialogIdentifier = container.ResolveRootDialogIdentifier();
            this.signIn = signIn;
            this.regionManager = regionManager;

            SignInCommand = new AsyncCommand(SignIn, () => settings.lastUser.IsValid);
            SignUpCommand = new DelegateCommand(dialogManager.ShowSignUpAsync);
            SetEnglishCommand = new DelegateCommand(SetEnglish);
        }

        /// <summary>
        /// Sign in command.
        /// </summary>
        public ICommand SignInCommand { get; }

        /// <summary>
        /// Set English command.
        /// </summary>
        public ICommand SetEnglishCommand { get; }

        /// <summary>
        /// Sign up command.
        /// </summary>
        public ICommand SignUpCommand { get; }

        /// <summary>
        /// Set English.
        /// </summary>
        private async void SetEnglish()
        {
            Settings.Default.lang = "en-US";
            Settings.Default.Save();

            var res = await dialogIdentifier.ShowMessageBoxAsync(Resources.ContinueInEnglish_Restart, MaterialMessageBoxButtons.YesNo);

            if (res == MaterialMessageBoxButtons.Yes)
                ProcessHelper.RestartApp();
        }

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
