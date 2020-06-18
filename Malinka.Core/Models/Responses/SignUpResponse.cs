using Malinka.Lang.Properties;

namespace Malinka.Core.Models.Responses
{
    /// <summary>
    /// Sign up response.
    /// </summary>
    public class SignUpResponse : IsSuccess
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public SignUpResponse(bool success) : base(success)
        {
        }

        public override string ToString()
        {
            return this ? null : Resources.Result_EMailAlreadyInUse;
        }
    }
}
