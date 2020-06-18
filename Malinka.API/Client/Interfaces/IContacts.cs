using Malinka.Core.Hubs;
using Malinka.Core.Models;

namespace Malinka.API.Client.Interfaces
{
    /// <summary>
    /// Contact action.
    /// </summary>
    /// <param name="user">User.</param>
    public delegate void ContactAction(MalinkaUser user);

    /// <summary>
    /// Contact removed.
    /// </summary>
    /// <param name="userId">Removed user id.</param>
    public delegate void ContactRemoved(int userId);

    /// <summary>
    /// Contacts service.
    /// </summary>
    public interface IContacts : IContactsHub
    {
        /// <summary>
        /// New user was added.
        /// </summary>
        event ContactAction UserAdded;

        /// <summary>
        /// User was removed.
        /// </summary>
        event ContactRemoved UserRemoved;

        /// <summary>
        /// User was changed (name, avatar, etc.).
        /// </summary>
        event ContactAction UserChanged;
    }
}
