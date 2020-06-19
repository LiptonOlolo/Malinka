using Malinka.Dialogs.Base;
using Malinka.Lang;
using Malinka.Lang.Models;
using MaterialDesignXaml.DialogsHelper;
using System.Collections.ObjectModel;

namespace Malinka.Dialogs.Settings
{
    /// <summary>
    /// Language selector view model.
    /// </summary>
    [DialogName(nameof(LanguageSelectorView))]
    class LanguageSelectorViewModel : BaseSelectorViewModel<Language>
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public LanguageSelectorViewModel()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public LanguageSelectorViewModel(IDialogIdentifier dialogIdentifier)
            : base(dialogIdentifier, new ObservableCollection<Language>(Languages.AllLanguages), Properties.Settings.Default.lang)
        {

        }
    }
}
