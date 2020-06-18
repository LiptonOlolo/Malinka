namespace Malinka.Dialogs.Manager
{
    /// <summary>
    /// Dialog view factory.
    /// </summary>
    interface IDialogViewFactory
    {
        /// <summary>
        /// Get view.
        /// </summary>
        /// <returns></returns>
        object GetView<TViewModel>(TViewModel viewModel);
    }
}
