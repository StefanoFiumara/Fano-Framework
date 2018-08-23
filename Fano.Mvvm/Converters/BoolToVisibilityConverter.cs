using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fano.Mvvm.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility FalseValue { get; set; }
        public Visibility TrueValue { get; set; }

        public BoolToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isTrue = value != null && (bool)value;

            return isTrue ? this.TrueValue : this.FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
