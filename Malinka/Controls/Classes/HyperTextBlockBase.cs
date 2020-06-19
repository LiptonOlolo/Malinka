using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Malinka.Controls.Classes
{
    public class HyperTextBlockBase : UserControl
    {
        public static readonly DependencyProperty HyperLinkStyleProperty =
            DependencyProperty.Register("HyperLinkStyle", typeof(Style), typeof(HyperTextBlockBase));

        public static readonly DependencyProperty HyperLinkForegroundProperty =
            DependencyProperty.Register("HyperLinkForeground", typeof(Brush), typeof(HyperTextBlockBase));

        public static readonly DependencyProperty HyperLinkTextProperty =
            DependencyProperty.Register("HyperLinkText", typeof(string), typeof(HyperTextBlockBase));

        public static readonly DependencyProperty HyperLinkCommandProperty =
            DependencyProperty.Register("HyperLinkCommand", typeof(ICommand), typeof(HyperTextBlockBase));

        public static readonly DependencyProperty HyperLinkTextFontWeightProperty =
            DependencyProperty.Register("HyperLinkTextFontWeight", typeof(FontWeight), typeof(HyperTextBlockBase));

        public Style HyperLinkStyle
        {
            get => (Style)GetValue(HyperLinkStyleProperty);
            set => SetValue(HyperLinkStyleProperty, value);
        }

        public Brush HyperLinkForeground
        {
            get => (Brush)GetValue(HyperLinkForegroundProperty);
            set => SetValue(HyperLinkForegroundProperty, value);
        }

        public string HyperLinkText
        {
            get => (string)GetValue(HyperLinkTextProperty);
            set => SetValue(HyperLinkTextProperty, value);
        }

        public ICommand HyperLinkCommand
        {
            get => (ICommand)GetValue(HyperLinkCommandProperty);
            set => SetValue(HyperLinkCommandProperty, value);
        }

        public FontWeight HyperLinkTextFontWeight
        {
            get => (FontWeight)GetValue(HyperLinkTextFontWeightProperty);
            set => SetValue(HyperLinkTextFontWeightProperty, value);
        }
    }
}
