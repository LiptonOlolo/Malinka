using Malinka.Core.Models.Enums;
using Malinka.Lang.Properties;

namespace Malinka.Core.Models.Responses
{
    /// <summary>
    /// Response from server.
    /// </summary>
    public class MalinkaResponse<T>
    {
        /// <summary>
        /// Request result.
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Server code.
        /// </summary>
        public ResponseCode Code { get; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="code">Code.</param>
        public MalinkaResponse(T result, ResponseCode code)
        {
            Result = result;
            Code = code;
        }

        public static implicit operator bool(MalinkaResponse<T> response) => response.Code == ResponseCode.Ok;
        public static implicit operator string(MalinkaResponse<T> response) => response.ToString();

        public override string ToString()
        {
            switch (Code)
            {
                case ResponseCode.Ok: return nameof(ResponseCode.Ok);
                case ResponseCode.InternalError: return Resources.Result_InternalServerError;
                case ResponseCode.ExternalError: return Resources.Result_ExternalServerError;
                default: return $"{nameof(ResponseCode)} is undefined (value: {(int)Code})";
            }
        }
    }

    /// <summary>
    /// Response from server.
    /// </summary>
    public class MalinkaResponse<T, TArgument> : MalinkaResponse<T>
    {
        /// <summary>
        /// Argument.
        /// </summary>
        public TArgument Argument { get; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="code">Code.</param>
        /// <param name="argument">Argument.</param>
        public MalinkaResponse(T result, ResponseCode code, TArgument argument) : base(result, code)
        {
            Argument = argument;
        }
    }
}
