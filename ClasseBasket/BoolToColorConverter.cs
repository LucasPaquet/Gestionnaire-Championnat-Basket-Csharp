using System.Globalization;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ClasseBasket
{
    // mon DataConverter
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Brushes.Green : Brushes.Red;
            }

            return DependencyProperty.UnsetValue; // Retourne DependencyProperty.UnsetValue si la conversion échoue
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                if (brush.Color == Brushes.Green.Color)
                {
                    return true;
                }
                else if (brush.Color == Brushes.Red.Color)
                {
                    return false;
                }
            }

            throw new NotSupportedException();
        }
    }
}