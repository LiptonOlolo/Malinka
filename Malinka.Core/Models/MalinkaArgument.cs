namespace Malinka.Core.Models
{
    /// <summary>
    /// Argument.
    /// </summary>
    public class MalinkaArgument<TArg>
    {
        /// <summary>
        /// Argument.
        /// </summary>
        public TArg Argument { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MalinkaArgument(TArg arg)
        {
            Argument = arg;
        }
    }
}
