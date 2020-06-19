using DryIoc;
using Malinka.Core.Models;
using Malinka.Dialogs.Settings;
using Malinka.Helpers;
using Malinka.Lang.Models;
using Malinka.Lang.Properties;
using MaterialDesignXaml.DialogsHelper;
using MaterialDesignXaml.DialogsHelper.Enums;
using System.Threading.Tasks;

namespace Malinka.Dialogs.Manager
{
    /// <summary>
    /// Dialog manager.
    /// </summary>
    class DialogManager : IDialogManager
    {
        /// <summary>
        /// View factory.
        /// </summary>
        readonly IDialogViewFactory viewFactory;

        /// <summary>
        /// Dialog identifier.
        /// </summary>
        readonly IDialogIdentifier dialogIdentifier;

        /// <summary>
        /// Container.
        /// </summary>
        readonly IContainer container;

        public DialogManager(IDialogViewFactory viewFactory, IContainer container)
        {
            this.viewFactory = viewFactory;
            dialogIdentifier = container.ResolveRootDialogIdentifier();
            this.container = container;
        }

        async Task<T> Show<T, TViewModel>(object[] args, IDialogIdentifier dialogIdentifier = null)
        {
            var vm = container.Resolve<TViewModel>(args: args);
            var view = viewFactory.GetView(vm);

            dialogIdentifier = dialogIdentifier ?? this.dialogIdentifier;

            var res = await dialogIdentifier.ShowAsync<T>(view);

            return res;
        }

        /// <summary>
        /// Show language selector.
        /// </summary>
        /// <returns></returns>
        public async void ShowLanguageSelector(IDialogIdentifier dialogIdentifier)
        {
            var res = await Show<Language, LanguageSelectorViewModel>(args: new[] { dialogIdentifier }, dialogIdentifier);

            if (res == null)
                return; //cancel

            Properties.Settings.Default.lang = res;
            Properties.Settings.Default.Save();

            var restart = await dialogIdentifier.ShowMessageBoxAsync(Resources.ChangeLanguageEN_Restart, MaterialMessageBoxButtons.YesNo);
            if (restart == MaterialMessageBoxButtons.Yes)
                ProcessHelper.RestartApp();
        }

        /// <summary>
        /// Show settings dialog.
        /// </summary>
        public async void ShowSettings(MalinkaUser user)
        {
            await Show<object, SettingsViewModel>(args: new[] { user });
        }

        /// <summary>
        /// Show sign up dialog.
        /// </summary>
        /// <returns></returns>
        public async void ShowSignUpAsync()
        {
            await Show<object, SignUpViewModel>(null);
        }
    }
}
