using DryIoc;
using Malinka.Models;
using Malinka.Properties;
using MaterialDesignThemes.Wpf;
using MaterialDesignXaml.DialogsHelper;

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
        /// Window settings.
        /// </summary>
        public WindowSettings WindowSettings { get; }

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

            WindowSettings = Settings.Default.MainWindowSettings;
        }
    }
}
