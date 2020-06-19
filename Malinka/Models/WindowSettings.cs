using System.Windows;

namespace Malinka.Models
{
    /// <summary>
    /// Window settings.
    /// </summary>
    public class WindowSettings
    {
        /// <summary>
        /// Window left position.
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Window top position.
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// Window Height.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Window width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Window state.
        /// </summary>
        public WindowState State { get; set; }

        /// <summary>
        /// Theme is dark.
        /// </summary>
        public bool ThemeIsDark { get; set; }
    }
}
