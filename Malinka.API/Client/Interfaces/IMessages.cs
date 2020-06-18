using Malinka.Core.Hubs;
using Malinka.Core.Models;

namespace Malinka.API.Client.Interfaces
{
    /// <summary>
    /// Message action.
    /// </summary>
    /// <param name="user">Sender.</param>
    /// <param name="message">Message.</param>
    public delegate void MessageAction(int sender, MalinkaMessage message);

    /// <summary>
    /// Messages services.
    /// </summary>
    public interface IMessages : IMessagesHub
    {
        /// <summary>
        /// Received new message.
        /// </summary>
        event MessageAction NewMessage;
    }
}
