using Malinka.Lang.Properties;

namespace Malinka.Core.Models.Responses
{
    /// <summary>
    /// Login response.
    /// </summary>
    public class LoginResponse : IsSuccess
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LoginResponse(bool success) : base(success)
        {
        }

        public override string ToString()
        {
            return this ? null : Resources.Result_EMailOrPasswordInvalid;
        }
    }
}
