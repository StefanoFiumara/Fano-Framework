using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FanoMvvm.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public Visibility FalseValue { get; set; }
        public Visibility TrueValue { get; set; }

        public NullToVisibilityConverter()
        {
            this.TrueValue = Visibility.Collapsed;
            this.FalseValue = Visibility.Visible;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? this.TrueValue : this.FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}