using DryIoc;
using MaterialDesignThemes.Wpf;
using MaterialDesignXaml.DialogsHelper;
using System.Windows.Input;

namespace Malinka.ViewModels
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    class MainWindowViewModel
    {
        /// <summary>
        /// Region manager.
        /// </summary>
        public IDialogIdentifier DialogIdentifier { get; }

        /// <summary>
        /// Message queue.
        /// </summary>
        public ISnackbarMessageQueue MessageQueue { get; }

        /// <summary>
        /// Ctor for design.
        /// </summary>
        public MainWindowViewModel()
        {

        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MainWindowViewModel(ISnackbarMessageQueue messageQueue, IContainer container)
        {
            MessageQueue = messageQueue;
            DialogIdentifier = container.ResolveRootDialogIdentifier();
        }
    }
}
