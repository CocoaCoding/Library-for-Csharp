using System;
using System.Globalization;
using System.Windows.Data;

namespace Hinzberg.WPF_Converter
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class FirstRegistrationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? ez = value as DateTime?;
            if (ez != null)
            {
                return ez?.ToString("MM") + "/" + ez?.ToString("yy");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Man kann aus einem zweistellingen Jahr nicht wieder ein DateTime machen. Zu ungenau.");
        }
    }
}
