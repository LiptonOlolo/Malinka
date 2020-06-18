using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Malinka.Converters
{
    [ValueConversion(typeof(int), typeof(Visibility))]
    class IntToVisibilityConverter : IValueConverter
    {
        public int CollapsedValue { get; set; }
        public bool Reverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = (int)value;
            Visibility negative = Reverse ? Visibility.Visible : Visibility.Collapsed;
            Visibility positive = Reverse ? Visibility.Collapsed : Visibility.Visible;

            return v <= CollapsedValue ? positive : negative;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
