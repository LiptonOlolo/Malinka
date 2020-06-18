using Malinka.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Malinka.API.Models
{
    /// <summary>
    /// Collection of Participant.
    /// </summary>
    public class ContactsCollection : ObservableCollection<Participant>
    {
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public MalinkaUser this[MalinkaUser user]
        {
            get => GetParticipant(user)?.User;
        }

        /// <summary>
        /// Get participant.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        public Participant GetParticipant(int userId)
        {
            var participant = this.FirstOrDefault(x => x.User.Id == userId);
            return participant;
        }

        /// <summary>
        /// Get participant.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        public Participant GetParticipant(MalinkaUser user)
        {
            int index = this.IndexOf(user);
            if (index == -1)
                return null;
            else return base[index];
        }

        /// <summary>
        /// Remove item from collection.
        /// </summary>
        /// <param name="user">User.</param>
        public void Remove(MalinkaUser user)
        {
            base.RemoveItem(this.IndexOf(user));
        }

        /// <summary>
        /// Remove item from collection by id.
        /// </summary>
        /// <param name="userId">User id.</param>
        public void Remove(int userId)
        {
            var first = this.FirstOrDefault(x => x.User.Id == userId);
            if (first != null)
                this.Remove(first);
        }

        /// <summary>
        /// Index of item.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        public int IndexOf(MalinkaUser user)
        {
            return this.IndexOf(x => x.User.Equals(user));
        }

        /// <summary>
        /// User is contains in collection.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns></returns>
        public bool Contains(int userId)
        {
            return this.Any(x => x.User.Id == userId);
        }

        /// <summary>
        /// User is contains in collection.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        public bool Contains(MalinkaUser user)
        {
            return this.Any(x => x.User.Equals(user));
        }

        /// <summary>
        /// Add a range of items to a collection.
        /// </summary>
        /// <param name="users">Users.</param>
        public void AddRange(IEnumerable<MalinkaUser> users)
        {
            users.ForEach(Add);
        }

        /// <summary>
        /// Add a item to a collection.
        /// </summary>
        /// <param name="user">User.</param>
        public void Add(MalinkaUser user)
        {
            base.Add(new Participant(user));
        }
    }
}
