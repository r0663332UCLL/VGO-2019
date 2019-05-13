using PiCross;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters
{
    public class ConstraintBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Value = (bool)value;
            if (Value)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
