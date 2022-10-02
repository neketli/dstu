using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace first
{
    /// <summary>
    /// Конвертер для деления числа на 2
    /// </summary>
    public class DivideByTwoConverter
        : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }
            return (double)value / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}