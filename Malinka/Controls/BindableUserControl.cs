using Malinka.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace Malinka.Controls
{
    public class BindableUserControl : UserControl
    { 
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(MalinkaUser), typeof(BindableUserControl));

        public MalinkaUser User
        {
            get => (MalinkaUser)GetValue(UserProperty);
            set => SetValue(UserProperty, value);
        }
    }
}
