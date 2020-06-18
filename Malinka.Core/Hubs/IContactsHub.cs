using Malinka.Core.Models;
using Malinka.Core.Models.Enums;

namespace Malinka.Core.Hubs
{
    /// <summary>
    /// Contacts hub.
    /// </summary>
    public interface IContactsHub : ICrudHub<MalinkaUser, ContactsResponseCode>
    {
    }
}
