using Malinka.API.Client.Interfaces;
using Malinka.Core.Models.Enums;
using Malinka.Core.Models.Responses;
using System.Threading.Tasks;

namespace Malinka.Client.Design
{
    class DesignSignUp : ISignUp
    {
        public Task<MalinkaResponse<SignUpResponse>> SignUpAsync(string email, string nickname)
        {
            return Task.FromResult(new MalinkaResponse<SignUpResponse>(new SignUpResponse(true), ResponseCode.Ok));
        }
    }
}
