using Malinka.Core.Models;
using System.Collections.ObjectModel;

namespace Malinka.API.Models
{
    /// <summary>
    /// Chat dialog.
    /// </summary>
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Participant
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        /// <summary>
        /// User.
        /// </summary>
        public MalinkaUser User { get; }

        /// <summary>
        /// Messages.
        /// </summary>
        public ObservableCollection<MalinkaMessage> Messages { get; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public Participant(MalinkaUser user)
        {
            Messages = new ObservableCollection<MalinkaMessage>();
            User = user;
        }

        public override bool Equals(object obj)
        {
            return obj is Participant participant && participant.User.Equals(User);
        }
    }
}
