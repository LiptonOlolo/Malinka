using Malinka.Core.Models.Responses;
using System.Threading.Tasks;

namespace Malinka.API.Client.Interfaces
{
    /// <summary>
    /// Sign up service.
    /// </summary>
    public interface ISignUp
    {
        /// <summary>
        /// Trying sign up.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="nickname">User nickname.</param>
        /// <returns></returns>
        Task<MalinkaResponse<SignUpResponse>> SignUpAsync(string email, string nickname);
    }
}
