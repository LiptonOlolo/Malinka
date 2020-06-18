using Malinka.API.Client.Interfaces;
using System;
using System.Threading.Tasks;

namespace Malinka.Client
{
    class DesignClient : IMalinkaClient
    {
        public event Action Disconnected;
        public event Action Connected;

        public ISignIn SignIn { get; }

        public ISignUp SignUp { get; }

        public IContacts Contacts { get; }

        public IMessages Messages { get; }

        public DesignClient(ISignIn signIn, ISignUp signUp, IContacts contacts, IMessages messages)
        {
            SignIn = signIn;
            SignUp = signUp;
            Contacts = contacts;
            Messages = messages;
        }

        public async void ConnectAsync()
        {
            await Task.Delay(500);

            Connected?.Invoke();
        }
    }
}
