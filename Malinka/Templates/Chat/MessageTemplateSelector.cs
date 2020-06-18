using Malinka.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Malinka.Templates.Chat
{
    /// <summary>
    /// Message template selector.
    /// </summary>
    class MessageTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Default message template.
        /// </summary>
        public DataTemplate TextMessageTemplate { get; set; }

        /// <summary>
        /// System message template.
        /// </summary>
        public DataTemplate SystemMessageTemplate { get; set; }

        /// <summary>
        /// Not handled message template.
        /// </summary>
        public DataTemplate NullTemplate { get; set; }

        /// <summary>
        /// Selecting selector.
        /// </summary>
        /// <param name="item">Object.</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TextMessage)
                return TextMessageTemplate;
            else if (item is SystemMessage)
                return SystemMessageTemplate;
            else return NullTemplate;
        }
    }
}
