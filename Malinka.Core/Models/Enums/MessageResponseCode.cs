namespace Malinka.Core.Models.Enums
{
    /// <summary>
    /// Send messsage result.
    /// </summary>
    public enum MessageResponseCode
    {
        /// <summary>
        /// Message sended.
        /// </summary>
        Ok,

        /// <summary>
        /// User is offline.
        /// </summary>
        UserIsOffline,

        /// <summary>
        /// Sender is in the black list.
        /// </summary>
        BlackList,
    }
}
