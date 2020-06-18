using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Malinka.Converters
{
    [ValueConversion(typeof(byte[]), typeof(BitmapSource))]
    class ByteBitmapSourceConverter : IValueConverter
    {
        public static ImageSourceConverter converter = new ImageSourceConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] arr)) return null;
            if (arr.Length == 0) return null;

            try
            {
                var bmpSrc = (BitmapSource)converter.ConvertFrom(arr);
                return bmpSrc;
            }
            catch { return null; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
