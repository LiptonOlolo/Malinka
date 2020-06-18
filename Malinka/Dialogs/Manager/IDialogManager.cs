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
        void ShowSettings();
    }
}
