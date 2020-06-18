using Malinka.Core.Models.Enums;
using Malinka.Lang.Properties;

namespace Malinka.Core.Models.Responses
{
    /// <summary>
    /// Message response.
    /// </summary>
    public class MessageResponse : MalinkaArgument<MessageResponseCode>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MessageResponse(MessageResponseCode responseCode) : base(responseCode)
        {
        }

        public static implicit operator bool(MessageResponse response) => response.Argument == MessageResponseCode.Ok;
        public static implicit operator string(MessageResponse response) => response.ToString();

        public override string ToString()
        {
            switch (base.Argument)
            {
                case MessageResponseCode.Ok: return nameof(MessageResponseCode.Ok);
                case MessageResponseCode.UserIsOffline: return Resources.Result_SendMessage_UserIsOffline;
                case MessageResponseCode.BlackList: return Resources.Result_SendMessage_BlackList;

                default: return $"{nameof(MessageResponseCode)} is undefined (value: {(int)base.Argument})";
            }
        }
    }
}
