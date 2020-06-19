using Malinka.Core.Models;
using MaterialDesignXaml.DialogsHelper;

namespace Malinka.Dialogs.Manager
{
    /// <summary>
    /// Dialog manager.
    /// </summary>
    interface IDialogManager
    {
        /// <summary>
        /// Show sign up dialog.
        /// </summary>
        /// <returns></returns>
        void ShowSignUpAsync();

        /// <summary>
        /// Show settings dialog.
        /// </summary>
        void ShowSettings(MalinkaUser user);

        /// <summary>
        /// Show language selector.
        /// </summary>
        /// <returns></returns>
        void ShowLanguageSelector(IDialogIdentifier dialogIdentifier);
    }
}
