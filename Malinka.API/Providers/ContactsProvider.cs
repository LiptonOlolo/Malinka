using Malinka.API.Client.Interfaces;
using Malinka.API.Models;
using Malinka.Core.Helpers.ChangeProps;
using Malinka.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Malinka.API.Providers
{
    /// <summary>
    /// Contacts provider.
    /// </summary>
    public class ContactsProvider : IContactsProvider, ILog<MalinkaUser>
    {
        /// <summary>
        /// Contacts.
        /// </summary>
        public ContactsCollection Contacts { get; }

        /// <summary>
        /// Contacts manager.
        /// </summary>
        readonly IContacts contacts;

        /// <summary>
        /// Sync.
        /// </summary>
        readonly TaskFactory sync;

        /// <summary>
        /// Ctor.
        /// </summary>
        public ContactsProvider(IContacts contacts, IMessages messages, TaskFactory sync)
        {
            this.contacts = contacts;
            this.sync = sync;

            contacts.UserAdded += Contacts_UserAdded;
            contacts.UserRemoved += Contacts_UserRemoved;
            contacts.UserChanged += Contacts_UserChanged;

            messages.NewMessage += Messages_NewMessage;

            Contacts = new ContactsCollection();
        }

        /// <summary>
        /// Recevied new message.
        /// </summary>
        /// <param name="sender">Sender id.</param>
        /// <param name="message">Message.</param>
        private async void Messages_NewMessage(int sender, MalinkaMessage message)
        {
            Logger.Log.Info($"Recevied new message from user id: {sender}, origin: {message.IsOriginNative}");

            if (!Contacts.Contains(sender))
            {
                var add = await AddUser(sender);
                if (!add)
                    return; //error
            }

            await sync.StartNew(() => Contacts.GetParticipant(sender).Messages.Add(message));
        }

        /// <summary>
        /// Add user by id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns></returns>
        public async Task<bool> AddUser(int id)
        {
            Logger.Log.Info($"Getting user by id (id: {id})");

            var res = await contacts.GetById(id);

            if (res)
            {
                Logger.Log.Info($"Received user by id {Log(res.Result)}");

                Contacts_UserAdded(res.Result);
            }
            else
            {
                Logger.Log.Error($"Getting user by id error: {res.Code}");
            }

            return res;
        }

        /// <summary>
        /// User was changed.
        /// </summary>
        /// <param name="user"></param>
        private void Contacts_UserChanged(MalinkaUser user)
        {
            if (Contacts.Contains(user))
            {
                sync.StartNew(() => Contacts[user].SetAllProperties(user));
                Logger.Log.Info($"User changed {Log(user)}");
            }
        }

        /// <summary>
        /// User was removed.
        /// </summary>
        private void Contacts_UserRemoved(int id)
        {
            if (Contacts.Contains(id))
            {
                sync.StartNew(() => Contacts.Remove(id));
                Logger.Log.Info($"User removed (id: {id})");
            }
        }

        /// <summary>
        /// User was added.
        /// </summary>
        private void Contacts_UserAdded(MalinkaUser user)
        {
            if (!Contacts.Contains(user))
            {
                sync.StartNew(() => Contacts.Add(user));
                Logger.Log.Info($"User added {Log(user)}");
            }
        }

        /// <summary>
        /// Load contacts.
        /// </summary>
        public async void Load()
        {
            Contacts.Clear();

            Logger.Log.Info($"Getting contacts");

            var res = await contacts.GetAllAsync();

            if (res)
            {
                Logger.Log.Info($"{res.Result.Count()} contacts recevied");
                Contacts.AddRange(res.Result);
            }
            else
            {
                Logger.Log.Error($"Gettings contacts error: {res.Code}");
            }
        }

        /// <summary>
        /// Get log string.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="args">Arguments.</param>
        /// <returns></returns>
        public string Log(MalinkaUser item, params object[] args)
        {
            return $"(name: {item.Name}, id: {item.Id})";
        }
    }
}
