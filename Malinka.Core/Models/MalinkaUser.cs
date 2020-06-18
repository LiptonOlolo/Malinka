namespace Malinka.Core.Models
{
    /// <summary>
    /// Malinka user.
    /// </summary>
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class MalinkaUser : BasePropertyChanged
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Avatar.
        /// </summary>
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Verified.
        /// </summary>
        public bool Verified { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MalinkaUser user && user.Id == Id;
        }
    }
}
