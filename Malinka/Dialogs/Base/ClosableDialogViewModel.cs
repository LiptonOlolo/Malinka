using DevExpress.Mvvm;
using DryIoc;
using MaterialDesignXaml.DialogsHelper;
using System.Windows.Input;

namespace Malinka.Dialogs.Base
{
    /// <summary>
    /// Base dialog view model.
    /// </summary>
    abstract class ClosableDialogViewModel : IClosableDialog
    {
        /// <summary>
        /// Owner identifier.
        /// </summary>
        public IDialogIdentifier OwnerIdentifier { get; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public ClosableDialogViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ClosableDialogViewModel(IContainer container)
        {
            OwnerIdentifier = container.ResolveRootDialogIdentifier();
            CloseDialogCommand = new DelegateCommand(CloseDialog);
        }

        /// <summary>
        /// Close dialog command.
        /// </summary>
        public ICommand CloseDialogCommand { get; }

        /// <summary>
        /// Close dialog.
        /// </summary>
        protected void CloseDialog()
        {
            OwnerIdentifier.Close();
        }
    }
}
