using DevExpress.Mvvm;
using MaterialDesignXaml.DialogsHelper;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Malinka.Dialogs.Base
{
    /// <summary>
    /// Base selector view model.
    /// </summary>
    class BaseSelectorViewModel<T> : ViewModelBase, IClosableDialog
    {
        /// <summary>
        /// Items.
        /// </summary>
        public ObservableCollection<T> Items { get; set; }

        /// <summary>
        /// Selected item.
        /// </summary>
        public T SelectedItem { get; set; }

        /// <summary>
        /// Owner dialog.
        /// </summary>
        public IDialogIdentifier OwnerIdentifier { get; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BaseSelectorViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseSelectorViewModel(IDialogIdentifier owner, ObservableCollection<T> items, T current)
        {
            OwnerIdentifier = owner;
            Items = items;
            SelectedItem = items.FirstOrDefault(x => x.Equals(current));

            CloseDialogCommand = new DelegateCommand(CloseCommand, () => SelectedItem != null);
        }

        /// <summary>
        /// Close command.
        /// </summary>
        public ICommand CloseDialogCommand { get; }

        /// <summary>
        /// Close.
        /// </summary>
        private void CloseCommand()
        {
            this.Close(SelectedItem);
        }
    }
}
