using Malinka.API.Client.Interfaces;
using Malinka.Core.Models;
using Malinka.Core.Models.Enums;
using Malinka.Core.Models.Responses;
using System.Threading.Tasks;

namespace Malinka.Client.Design
{
    class DesignSignIn : ISignIn
    {
        public Task<MalinkaResponse<MalinkaUser, LoginResponse>> SignInAsync(string email, string password)
        {
            return Task.FromResult(new MalinkaResponse<MalinkaUser, LoginResponse>(new MalinkaUser
            {
                Id = 1337,
                Name = "Design name, very long name",
                Verified = true
            }, ResponseCode.Ok, new LoginResponse(true)));
        }

        public void LogOutAsync()
        {

        }
    }
}
