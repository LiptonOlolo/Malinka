using DevExpress.Mvvm;
using DryIoc;
using MaterialDesignXaml.DialogsHelper;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Malinka.Dialogs.Base
{
    /// <summary>
    /// Base dialog view model.
    /// </summary>
    abstract class CanClosableDialogViewModel : IClosableDialog
    {
        /// <summary>
        /// Owner identifier.
        /// </summary>
        public IDialogIdentifier OwnerIdentifier { get; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public CanClosableDialogViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CanClosableDialogViewModel(IContainer container)
        {
            OwnerIdentifier = container.ResolveRootDialogIdentifier();
            CloseDialogCommand = new AsyncCommand(CloseDialog, CanCloseDialog);
        }

        /// <summary>
        /// Close dialog command.
        /// </summary>
        public ICommand CloseDialogCommand { get; }

        /// <summary>
        /// Can close dialog.
        /// </summary>
        /// <returns></returns>
        protected abstract bool CanCloseDialog();

        /// <summary>
        /// Close dialog.
        /// </summary>
        protected abstract Task CloseDialog();
    }
}
