using DryIoc;
using Malinka.Dialogs.Settings;
using MaterialDesignXaml.DialogsHelper;
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
        /// Show settings dialog.
        /// </summary>
        public async void ShowSettings()
        {
            await Show<object, SettingsViewModel>(null);
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
