namespace Malinka.Core.Models
{
    /// <summary>
    /// Success status.
    /// </summary>
    public class IsSuccess : MalinkaArgument<bool>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public IsSuccess(bool success) : base(success)
        {
        }

        public static implicit operator bool(IsSuccess isSuccess) => isSuccess.Argument;
    }
}
