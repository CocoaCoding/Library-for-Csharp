using System.Text;

namespace Hinzberg.Extensions.String
{
    public static class string_extensions
    {
        private static string OnlyDigits(string text)
        {  
            StringBuilder sb = new StringBuilder();      
            foreach(char c in text)
            {
                if(char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static int ToInt(this string text)
        {
            int r = default(int);
            text = OnlyDigits(text);
            int.TryParse(text, out r);
            return r;
        }
        public static long ToLong(this string text)
        {
            long r = default(long);
            text = OnlyDigits(text);
            long.TryParse(text, out r);
            return r;
        }    
        public static byte ToByte(this string text)
        {
            byte r= default(byte);



            text = OnlyDigits(text);
            byte.TryParse(text, out r);
            return r;
        }

    }
}
