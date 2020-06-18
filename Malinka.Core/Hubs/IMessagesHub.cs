using Malinka.Core.Models.Responses;
using System.Threading.Tasks;

namespace Malinka.Core.Hubs
{
    /// <summary>
    /// Messages hub.
    /// </summary>
    public interface IMessagesHub
    {
        /// <summary>
        /// Send message to client.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="messageText">Message text.</param>
        /// <returns></returns>
        Task<MalinkaResponse<MessageResponse>> SendMessageAsync(int userId, string messageText);
    }
}
