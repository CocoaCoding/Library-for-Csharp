using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hinzberg.Helper.Format
{
    public static class FormatHelper
    {
        private const string DISTANCE_FROM_TEXT = "km von";
        /// <summary>
        /// Example: (3800,"€") returns -> 3.800 €
        /// </summary>
        /// <param name="number"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetNumberWithUnit(int number, string unit)
        {
            string formattedNumberWithUnit = "";

            if (number != 0)
            {
                formattedNumberWithUnit = GetFormattedNumber(number) + " " + unit;
            }
            return formattedNumberWithUnit;
        }
        public static string GetNumberWithUnit(long number, string unit)
        {
            string formattedNumberWithUnit = "";

            if (number != 0)
            {
                formattedNumberWithUnit = GetFormattedNumber(number) + " " + unit;
            }
            return formattedNumberWithUnit;
        }

        public static string GetFormattedPrices(int priceBrutto, int priceNetto, int priceMwSt)
        {
            string formattedPrices = GetNumberWithUnit(priceBrutto, "€") + " Brutto, " + GetNumberWithUnit(priceNetto, "€") + " Netto, " + GetNumberWithUnit(priceMwSt, "€") + "  MwSt.";
            return formattedPrices;
        }

        /// <summary>
        /// Bsp.: 123 km von 59065
        /// </summary>
        /// <param name="distance">Entfernung</param>
        /// <param name="zipCode">PLZ</param>
        /// <returns></returns>
        public static string GetDistanceText(int distance, string zipCode)
        {
            return string.Format("{0} {1} {2}", distance, DISTANCE_FROM_TEXT, zipCode);
        }

        /// <summary>
        /// Bsp.: 123 km von 59065 (VirtualOffice)
        /// </summary>
        /// <param name="distance">Entfernung</param>
        /// <param name="zipCode">PLZ</param>
        /// <param name="description">Beschreibung</param>
        /// <returns></returns>
        public static string GetDistanceTextWithDescription(int distance, string zipCode, string description)
        {
            string distanceText = string.Empty;

            distanceText = GetDistanceText(distance, zipCode);
            if (!string.IsNullOrEmpty(description))
                distanceText += " (" + description + ")";
            return distanceText;
        }

        /// <summary>
        /// Gibt den Text "null" bzw. "empty" zurück, wenn der übergebene Parameter null bzw. string.Empty ist, andernfalls wird .ToString() zurückgegeben.
        /// </summary>
        /// <returns>Gibt den Text "null" bzw. "empty" zurück, wenn der übergebene Parameter null bzw. empty ist.</returns>
        public static string GetEmptyNullableText(object value)
        {
            string textValue;

            if (value == null)
                textValue = "null";
            else if (value is string && value.ToString() == string.Empty)
                textValue = "empty";
            else
                textValue = value.ToString();
            return textValue;
        }

        /// <summary>
        /// Gibt den Text "null" zurück, wenn der übergebene Parameter null ist, andernfalls wird .ToString() zurückgegeben.
        /// </summary>
        /// <returns>Gibt den Text "null" zurück, wenn der übergebene Parameter null ist.</returns>
        public static string GetNullableText(object value)
        {
            string textValue;

            if (value == null)
                textValue = "null";
            else
                textValue = value.ToString();
            return textValue;
        }

        /// <summary>
        /// Gibt bei true "Ja" und bei false "Nein" zurück.
        /// </summary>
        /// <returns>"Ja" oder "Nein".</returns>
        public static string GetDisplayBoolText(bool value)
        {
            string displayText;

            if (value)
                displayText = "Ja";
            else
                displayText = "Nein";

            return displayText;
        }
        public static string GetShortFormattedDateTextFrom(DateTime value)
        {
            string text = string.Empty;

            if (value != null && value != default(DateTime))
            {
                text = value.ToString("MM") + "/" + value.ToString("yy");
            }
            return text;
        }
        private static string GetFormattedNumber(int number)
        {
            string formattedNumber = "";

            if (number != 0)
            {
                formattedNumber = number.ToString("N0");
            }
            return formattedNumber;
        }
        private static string GetFormattedNumber(long number)
        {
            string formattedNumber = "";

            if (number != 0)
            {
                formattedNumber = number.ToString("N0");
            }
            return formattedNumber;
        }

        /// <summary>
        /// Monat/Jahr.
        /// z.B.: 06/09
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetShortFormattedDateText(string value)
        {
            string shortDate = string.Empty;
            string year;
            string month;

            if (!string.IsNullOrEmpty(value) && value.Length == 6)
            {
                year = value.Substring(2, 2);
                month = value.Substring(4, 2);
                shortDate = string.Format("{0}/{1}", month, year);
            }
            return shortDate;
        }


        public static string FormatMobileJsonStringToHtmlText(string jsonString)
        {
            string formattedHtmlText = jsonString;

            if (!string.IsNullOrEmpty(formattedHtmlText))
            {
                formattedHtmlText = formattedHtmlText.Replace("Ã¤", "ä");
                formattedHtmlText = formattedHtmlText.Replace("Ã„", "Ä");
                formattedHtmlText = formattedHtmlText.Replace("Ã¶", "ö");
                formattedHtmlText = formattedHtmlText.Replace("Ã–", "Ö");
                formattedHtmlText = formattedHtmlText.Replace("Ã¼", "ü");
                formattedHtmlText = formattedHtmlText.Replace("Ãœ", "Ü");
                formattedHtmlText = formattedHtmlText.Replace("ÃŸ", "ß ");

                formattedHtmlText = formattedHtmlText.Replace("\\u0026", "&");              // "&"
                formattedHtmlText = formattedHtmlText.Replace("\\\\\\\\", "<br>");          // Zeilenumbruch
                if (formattedHtmlText.Contains("**"))
                {
                    formattedHtmlText = SetHtmlTagsBy(formattedHtmlText);
                }
                formattedHtmlText = formattedHtmlText.Replace("✅", string.Empty);          // "✅"
                formattedHtmlText = formattedHtmlText.Replace("\\u003d", "=");              // "="       
                formattedHtmlText = formattedHtmlText.Replace("\\u0027", "'");              // "'"
                formattedHtmlText = formattedHtmlText.Replace("\\u003c", "<");              // "<" 
                formattedHtmlText = formattedHtmlText.Replace("\\u003e", ">");              // ">"
                formattedHtmlText = formattedHtmlText.Replace("\\\"", "\"");                // """
                formattedHtmlText = formattedHtmlText.Replace("\\r\\n", "<br><br>");
                formattedHtmlText = formattedHtmlText.Replace("\\r", "<br>");
                formattedHtmlText = formattedHtmlText.Replace("\\n", "<br>");
                formattedHtmlText = formattedHtmlText.Replace("\r\n", "<br>");
                formattedHtmlText = formattedHtmlText.Replace("----", "<br><br><hr><br>");
                formattedHtmlText = formattedHtmlText.Replace("\t*", "*");
            }
            return formattedHtmlText;
        }

        /// <summary> 
        /// Ersetzt im übergebenem Text eine übergebene Zeichenfolge mit übergebenen HtmlTags 
        /// </summary>
        /// <param name="textToFormat"> Übergebener Text</param>
        /// <param name="textToReplace">Zeicehnfolge, welche im übergebenem Text ersetzt werden soll.</param>
        /// <param name="htmlStartTag">Anfangs Html-Tag, welcher für die Zeichenfolge ersetzt wird.</param>
        /// <param name="htmlEndTag">End Html-Tag, welcher für die Zeichenfolge ersetzt wird.</param>
        /// <returns></returns>
        private static string SetHtmlTagsBy(string textToFormat)       // TODO [em] Refactoring und in FormatHelper + wtf ich weiß nicht mehr was der Quellcode macht
        {
            if (textToFormat != null && textToFormat.Contains("**"))
            {
                bool condition = true;
                do
                {
                    if (condition)
                    {
                        string textToReplace = string.Empty;
                        string formattedHtmlText = string.Empty;

                        int startIndex = textToFormat.IndexOf("**");
                        if (startIndex != -1 && startIndex + 2 <= textToFormat.Length)
                        {
                            int endIndex = textToFormat.IndexOf("**", startIndex + 2);
                            if (endIndex != -1 && endIndex + 2 <= textToFormat.Length)
                            {
                                int length = (endIndex - startIndex) + 2;
                                textToReplace = textToFormat.Substring(startIndex, length);
                                if (!string.IsNullOrEmpty(textToReplace))
                                {
                                    formattedHtmlText = textToReplace.Replace("**", string.Empty);
                                    formattedHtmlText = string.Format("<b>{0}</b>", formattedHtmlText);
                                }
                                if (!string.IsNullOrEmpty(textToReplace) && !string.IsNullOrEmpty(formattedHtmlText))
                                {
                                    textToFormat = textToFormat.Replace(textToReplace, formattedHtmlText);
                                }
                            }
                            else
                            {
                                condition = false;
                            }
                        }
                        else
                        {
                            condition = false;
                        }
                    }
                } while (condition);
            }
            return textToFormat;
        }
    }
}
