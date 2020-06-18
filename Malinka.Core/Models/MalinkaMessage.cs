using Newtonsoft.Json;
using System;

namespace Malinka.Core.Models
{
    /// <summary>
    /// Message.
    /// </summary>
    public class MalinkaMessage
    {
        /// <summary>
        /// Message body.
        /// </summary>
        [JsonProperty("o")]
        public object Body { get; set; }

        /// <summary>
        /// Date received.
        /// </summary>
        [JsonProperty("d")]
        public DateTime Date { get; } = DateTime.Now;

        /// <summary>
        /// True - you are sender.
        /// </summary>
        [JsonProperty("io")]
        public bool IsOriginNative { get; set; }
    }
}
