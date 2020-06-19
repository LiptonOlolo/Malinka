namespace Malinka.Lang.Models
{
    /// <summary>
    /// Language for UI.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Short name (example: ru-RU).
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Display (example: Русский).
        /// </summary>
        public string Display { get; set; }

        public Language()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Language(string shortName, string display)
        {
            ShortName = shortName;
            Display = display;
        }

        public override bool Equals(object obj)
        {
            return (obj is Language language) && language.ShortName == ShortName;
        }
    }
}
