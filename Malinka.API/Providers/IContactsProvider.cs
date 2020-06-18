using Malinka.API.Models;
using System.Threading.Tasks;

namespace Malinka.API.Providers
{
    /// <summary>
    /// Contacts provider.
    /// </summary>
    public interface IContactsProvider
    {
        /// <summary>
        /// Contacts.
        /// </summary>
        ContactsCollection Contacts { get; }

        /// <summary>
        /// Load contacts.
        /// </summary>
        void Load();

        /// <summary>
        /// Add user by id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns></returns>
        Task<bool> AddUser(int id);
    }
}