using DevExpress.Mvvm;
using DryIoc;
using Malinka.Core.Models;
using Malinka.Dialogs.Base;
using Malinka.Dialogs.Manager;
using MaterialDesignXaml.DialogsHelper;
using System;
using System.Windows.Input;

namespace Malinka.Dialogs.Settings
{
    /// <summary>
    /// Settings view model.
    /// </summary>
    [DialogName(nameof(SettingsView))]
    class SettingsViewModel : ClosableDialogViewModel, IDialogIdentifier
    {
        /// <summary>
        /// Current user.
        /// </summary>
        public MalinkaUser User { get; }

        /// <summary>
        /// Dialog identifier.
        /// </summary>
        public string Identifier => nameof(SettingsViewModel);

        /// <summary>
        /// Dialog manager.
        /// </summary>
        readonly IDialogManager dialogManager;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public SettingsViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsViewModel(MalinkaUser user, IDialogManager dialogManager, IContainer container) : base(container)
        {
            this.dialogManager = dialogManager;

            User = user;

            ShowSelectLanguageCommand = new DelegateCommand(ShowSelectLanguage);
            ShowColorSelectorCommand = new DelegateCommand(ShowColorSelector);
        }

        /// <summary>
        /// Show language selector.
        /// </summary>
        public ICommand ShowSelectLanguageCommand { get; }

        /// <summary>
        /// Show color selector.
        /// </summary>
        public ICommand ShowColorSelectorCommand { get; }

        /// <summary>
        /// Show color selector.
        /// </summary>
        private void ShowColorSelector()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Show language selector.
        /// </summary>
        private void ShowSelectLanguage()
        {
            dialogManager.ShowLanguageSelector(this);
        }
    }
}
