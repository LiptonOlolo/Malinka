using Malinka.API.Client.Interfaces;
using Malinka.Core.Models;
using Malinka.Core.Models.Enums;
using Malinka.Core.Models.Responses;
using System;
using System.Threading.Tasks;

namespace Malinka.Client.Design
{
    class DesignMessages : IMessages
    {
        static Random rn = new Random();

        public DesignMessages()
        {

        }

        public event MessageAction NewMessage;

        /// <summary>
        /// Send message to client.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="messageText">Message text.</param>
        /// <returns></returns>
        public Task<MalinkaResponse<MessageResponse>> SendMessageAsync(int userId, string messageText)
        {
            NewMessage?.Invoke(userId, new TextMessage { Body = messageText, IsOriginNative = rn.Next(0, 2) == 0 });
            NewMessage?.Invoke(userId, new SystemMessage { Body = messageText });

            return Task.FromResult(new MalinkaResponse<MessageResponse>(new MessageResponse(MessageResponseCode.Ok), ResponseCode.Ok));
        }
    }
}
