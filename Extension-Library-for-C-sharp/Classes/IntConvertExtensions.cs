using System.Globalization;

namespace Hinzberg.Extensions.Int
{
    public static partial class Int
    {
        public static string ToDecimalString(this int selfInt)
        {
            string strValue = selfInt.ToString();
            int intValue = 0;
            
            if (true == int.TryParse(strValue, out intValue))
            {
                NumberFormatInfo formatInfo = new CultureInfo("de-DE").NumberFormat;
                return System.String.Format(intValue.ToString("N0", formatInfo));
            }
            return "";
        }
    }
}
