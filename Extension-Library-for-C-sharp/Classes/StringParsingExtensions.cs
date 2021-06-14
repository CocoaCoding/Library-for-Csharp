namespace Hinzberg.Extensions.String
{
    public static partial class String
    {
        /// <summary>
        /// Teilstring ab eine angegebenen Zeichenkette
        /// inklusive der angegebenen Zeichenkette
        /// </summary>
        /// <param name="selfString"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static string StringFrom(this string selfString, string searchString)
        {
            string resultString = selfString;
            if (resultString.Contains(searchString))
            {
                resultString = resultString.Substring(resultString.IndexOf(searchString));
            }
            return resultString;
        }

        /// <summary>
        ///  Teilstring bis zu einer angegebenen Zeichenkette
        /// </summary>
        /// <param name="selfString"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static string StringTill(this string selfString, string searchString)
        {
            string resultString = selfString;
            if (resultString.Contains(searchString))
            {
                resultString = resultString.Substring(0, resultString.IndexOf(searchString));
            }
            return resultString;
        }

        /// <summary>
        /// Teilstring nach einer angegebenen Zeichenkette
        /// </summary>
        /// <param name="selfString"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static string StringAfter(this string selfString, string searchString)
        {
            string resultString = selfString;
            if (resultString.Contains(searchString))
            {
                resultString = resultString.Substring(resultString.IndexOf(searchString) + searchString.Length);
            }
            return resultString;
        }

        public static string StringBetween(this string selfString, string startTag, string endTag)
        {
            string resultString = selfString;

            if (resultString.Contains(startTag))
            {
                resultString = resultString.Substring(resultString.IndexOf(startTag) + startTag.Length);
            }

            if (resultString.Contains(endTag))
            {
                resultString = resultString.Substring(0, resultString.IndexOf(endTag));
            }

            return resultString;
        }

        public static string TruncateLength(this string selfString, int maxLength)
        {
            if (selfString.Length > maxLength)
                selfString = selfString.Substring(0, maxLength);

            return selfString;
        }
    }
}
