using System.Globalization;

namespace Hinzberg.Extensions.Decimal
{
    public static partial class Decimal
    {
        public static string ToDecimalString(this decimal selfDecimal)
        {
            string strValue = selfDecimal.ToString();
            decimal decimalValue = 0;

            if (true == decimal.TryParse(strValue, out decimalValue))
            {
                NumberFormatInfo formatInfo = new CultureInfo("de-DE").NumberFormat;
                return System.String.Format(decimalValue.ToString("N0", formatInfo));
            }
            return "";
        }
    }
}
