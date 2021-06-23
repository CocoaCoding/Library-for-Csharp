using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hinzberg.WPF_Converter
{
    [ValueConversion(typeof(int), typeof(String))]
    public class MileageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mileage = (int)value;
            if (mileage > 0)
            {
                return mileage.ToString("N0") + " km";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            strValue = strValue.Replace("km", "");
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
