using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hinzberg.WPF_Converter
{
    [ValueConversion(typeof(int), typeof(String))]
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int price = (int)value;
            if (price > 0)
            {
               return price.ToString("N0") + " €";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            strValue = strValue.Replace("€", "");
            strValue = strValue.Trim();

            int intValue;
            if (int.TryParse(strValue, out intValue))
            {
                return intValue;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
