using Malinka.Lang.Models;
using System.Collections.Generic;

namespace Malinka.Lang
{
    /// <summary>
    /// Languages.
    /// </summary>
    public static class Languages
    {
        /// <summary>
        /// List of languages.
        /// </summary>
        public static List<Language> AllLanguages = new List<Language>();

        /// <summary>
        /// Constructor.
        /// </summary>
        static Languages()
        {
            AllLanguages.Add(Default);
            AllLanguages.Add(EN);
        }

        /// <summary>
        /// Default language.
        /// </summary>
        public static Language Default = new Language("ru-RU", "Русский");

        /// <summary>
        /// en-US language.
        /// </summary>
        public static Language EN = new Language("en-US", "English");
    }
}
