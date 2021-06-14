namespace Hinzberg.Extensions.String
{
    public static partial class String
    {
        public static bool CaseInsensitiveContains(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string heper2 = value.ToLower();
            return helper1.Contains(heper2);
        }

        public static bool CaseInsensitiveMatch(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            return helper1 == helper2;
        }

        public static bool CaseInsensitiveMatchTrimmed(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            return helper1.Trim() == helper2.Trim();
        }

        public static bool CaseInsensitiveEndsWith(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            return helper1.EndsWith(helper2);
        }

        public static bool CaseInsensitiveStartsWith(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            return helper1.StartsWith(helper2);
        }

        public static bool CaseInsensitiveContainsWithOutSpaces(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            helper1 = helper1.Replace(" ", "");
            helper2 = helper2.Replace(" ", "");
            return helper1.Contains(helper2);
        }

        public static bool CaseInsensitiveContainsWithOutSpacesAndDash(this string selfString, string value)
        {
            string helper1 = selfString.ToLower();
            string helper2 = value.ToLower();
            helper1 = helper1.Replace(" ", "");
            helper2 = helper2.Replace(" ", "");
            helper1 = helper1.Replace("-", "");
            helper2 = helper2.Replace("-", "");
            return helper1.Contains(helper2);
        }
    }
}
