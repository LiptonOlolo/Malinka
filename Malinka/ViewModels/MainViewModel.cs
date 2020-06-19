using DevExpress.Mvvm;
using Malinka.API.Client.Interfaces;
using Malinka.API.Models;
using Malinka.API.Providers;
using Malinka.Client.Design;
using Malinka.Controls.ChatLeftMenu;
using Malinka.Core.Models;
using Malinka.Properties;
using Malinka.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using Prism.Events;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Malinka.ViewModels
{
    /// <summary>
    /// Main view model.
    /// </summary>
    class MainViewModel : NavigationViewModel
    {
        #region Public properties
        /// <summary>
        /// Participants.
        /// </summary>
        public ListCollectionView Contacts { get; }

        /// <summary>
        /// Selected participant.
        /// </summary>
        public Participant SelectedContact { get; set; }

        /// <summary>
        /// Contacts width.
        /// </summary>
        public GridLength ContactsWidth
        {
            get => Settings.Default.contactsWidth;
            set => Settings.Default.contactsWidth = value;
        }

        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; set; } = "";

        string filter = "";
        /// <summary>
        /// Contacts filter text.
        /// </summary>
        public string ContactsFilterText
        {
            get => filter;
            set
            {
                filter = value;
                Contacts.Refresh();
            }
        }

        /// <summary>
        /// Main menu status.
        /// </summary>
        public MainMenuStatus MainMenuStatus { get; }
        #endregion

        #region Readonly fields
        /// <summary>
        /// Malinka client.
        /// </summary>
        readonly IMalinkaClient malinkaClient;

        /// <summary>
        /// Contacts provider.
        /// </summary>
        readonly IContactsProvider contactsProvider;

        /// <summary>
        /// Message queue.
        /// </summary>
        readonly ISnackbarMessageQueue messageQueue;
        #endregion

        /// <summary>
        /// Ctor for design.
        /// </summary>
        public MainViewModel()
        {
            var collection = new ContactsCollection();
            Contacts = new ListCollectionView(collection);

            var participants = new DesignContacts().GetAllAsync().Result;
            collection.AddRange(participants.Result);
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MainViewModel(IMalinkaClient malinkaClient,
                             IContactsProvider contactsProvider,
                             ISnackbarMessageQueue messageQueue,
                             PubSubEvent hotkeyEvent,
                             MainMenuStatus menuStatus,
                             MalinkaUser user) : base(user)
        {
            this.malinkaClient = malinkaClient;
            this.contactsProvider = contactsProvider;
            this.messageQueue = messageQueue;
            MainMenuStatus = menuStatus;

            hotkeyEvent.Subscribe(() => SelectedContact = null);

            Contacts = new ListCollectionView(contactsProvider.Contacts);
            Contacts.Filter += FilterContacts;

            SendMessageCommand = new AsyncCommand(SendMessage);
        }

        /// <summary>
        /// Filter contacts.
        /// </summary>
        /// <param name="obj">Participant.</param>
        /// <returns></returns>
        private bool FilterContacts(object obj)
        {
            var participant = obj as Participant;
            return participant.User.Name.Contains(ContactsFilterText);
        }

        /// <summary>
        /// Send message command.
        /// </summary>
        public ICommand SendMessageCommand { get; }

        /// <summary>
        /// Send message.
        /// </summary>
        /// <returns></returns>
        private async Task SendMessage()
        {
            if (MessageText.IsEmpty())
                return;

            var temp = MessageText;
            MessageText = "";

            var res = await malinkaClient.Messages.SendMessageAsync(SelectedContact.User.Id, temp);

            if (!res)
            {
                messageQueue.EnqueueWithCloseButton(res);
                Logger.Log.Error($"Message was not sended: {res.Code} {GetLog()}");
            }
            else if (!res.Result)
            {
                messageQueue.EnqueueWithCloseButton(res.Result);
                Logger.Log.Warn($"Message was not sended, reason: {res.Result.Argument} {GetLog()}");
            }
            else
            {
                Logger.Log.Info($"Sended message {GetLog()}");
            }

            string GetLog() => $"(to: {SelectedContact.User.Name}, id: {SelectedContact.User.Id})";
        }

        /// <summary>
        /// Navigated to.
        /// </summary>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            contactsProvider.Load();
        }
    }
}
