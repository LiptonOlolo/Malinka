using System;

namespace Malinka.API.Client.Interfaces
{
    /// <summary>
    /// Malinka client.
    /// </summary>
    public interface IMalinkaClient
    {
        /// <summary>
        /// Called when client disconnected from server.
        /// </summary>
        event Action Disconnected;

        /// <summary>
        /// Called when client connected to server.
        /// </summary>
        event Action Connected;

        /// <summary>
        /// Connect to server.
        /// </summary>
        void ConnectAsync();

        /// <summary>
        /// Sign in service.
        /// </summary>
        ISignIn SignIn { get; }

        /// <summary>
        /// Sign up service.
        /// </summary>
        ISignUp SignUp { get; }

        /// <summary>
        /// Contacts service.
        /// </summary>
        IContacts Contacts { get; }

        /// <summary>
        /// Messages service.
        /// </summary>
        IMessages Messages { get; }
    }
}
