using DevExpress.Mvvm;
using DryIoc;
using MaterialDesignXaml.DialogsHelper;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Malinka.Dialogs
{
    /// <summary>
    /// Base dialog view model.
    /// </summary>
    abstract class BaseDialogViewModel : IClosableDialog
    {
        /// <summary>
        /// Owner identifier.
        /// </summary>
        public IDialogIdentifier OwnerIdentifier { get; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BaseDialogViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseDialogViewModel(IContainer container)
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
