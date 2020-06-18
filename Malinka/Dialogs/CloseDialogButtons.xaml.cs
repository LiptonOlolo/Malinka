using System.Windows;
using System.Windows.Controls.Primitives;

namespace Malinka.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для CloseDialogButtons.xaml
    /// </summary>
    public partial class CloseDialogButtons : UniformGrid
    {
        public static readonly DependencyProperty CloseButtonContentProperty =
            DependencyProperty.Register("CloseButtonContent", typeof(object), typeof(CloseDialogButtons), new PropertyMetadata("Ok"));

        public CloseDialogButtons()
        {
            InitializeComponent();
        }

        public object CloseButtonContent
        {
            get => GetValue(CloseButtonContentProperty);
            set => SetValue(CloseButtonContentProperty, value);
        }
    }
}
