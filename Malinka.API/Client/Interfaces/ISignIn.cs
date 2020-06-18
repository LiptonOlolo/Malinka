using Malinka.Core.Models;
using Malinka.Core.Models.Responses;
using System.Threading.Tasks;

namespace Malinka.API.Client.Interfaces
{
    /// <summary>
    /// Sign in service.
    /// </summary>
    public interface ISignIn
    {
        /// <summary>
        /// Trying login to server.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns></returns>
        Task<MalinkaResponse<MalinkaUser, LoginResponse>> SignInAsync(string email, string password);

        /// <summary>
        /// Log out from server.
        /// </summary>
        /// <returns></returns>
        void LogOutAsync();
    }
}
