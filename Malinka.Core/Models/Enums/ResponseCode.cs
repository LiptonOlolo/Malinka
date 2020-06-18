namespace Malinka.Core.Models.Enums
{
    /// <summary>
    /// Server code.
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Ok.
        /// </summary>
        Ok,

        /// <summary>
        /// Client error.
        /// </summary>
        InternalError,

        /// <summary>
        /// Server error (db, etc.).
        /// </summary>
        ExternalError,
    }
}
