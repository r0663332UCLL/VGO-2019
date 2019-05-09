﻿
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace View
{
    public class ConstraintValueBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Value = (bool)value;
            if (Value)
            {
                return new SolidColorBrush(Colors.White);
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
