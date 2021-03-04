using System.Text;

namespace Exercise.H4x0rR4nk.XorStrings
{
    // https://www.hackerrank.com/challenges/strings-xor/problem
    public class StringXorator
    {
        public static string strings_xor(string s, string t)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t[i])
                {
                    sb.Append('0');
                }
                else
                {
                    sb.Append('1');
                }
            }

            return sb.ToString();
        }
    }
}
