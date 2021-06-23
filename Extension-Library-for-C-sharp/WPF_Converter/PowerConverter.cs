using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hinzberg.WPF_Converter
{
    [ValueConversion(typeof(int), typeof(String))]
    public class PowerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int power = (int)value;
            if (power > 0)
            {
                return power.ToString("N0") + " kW";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            strValue = strValue.Replace("kW", "");
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
