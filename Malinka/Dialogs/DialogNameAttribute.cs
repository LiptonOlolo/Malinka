using System;

namespace Malinka.Dialogs
{
    /// <summary>
    /// Dialog name attribute.
    /// </summary>
    class DialogNameAttribute : Attribute
    {
        /// <summary>
        /// View name.
        /// </summary>
        public string View { get; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public DialogNameAttribute(string view)
        {
            View = view;
        }
    }
}
