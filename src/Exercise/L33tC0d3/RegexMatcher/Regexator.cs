namespace Exercise.L33tC0d3.RegexMatcher
{
    // https://leetcode.com/problems/regular-expression-matching/
    public class Regexator
    {
        public bool IsMatch(string s, string p)
        {
            // dynamic programming (https://en.wikipedia.org/wiki/Dynamic_programming)
            // (implementation taken from LeetCode)
            bool[,] memo = new bool[s.Length + 1, p.Length + 1];
            memo[s.Length, p.Length] = true;

            for (int i = s.Length; i >= 0; i--)
            {
                for (int j = p.Length - 1; j >= 0; j--)
                {
                    var firstMatch = (i < s.Length && (p[j] == s[i] || p[j] == '.'));

                    if (j + 1 < p.Length && p[j + 1] == '*')
                    {
                        memo[i, j] = memo[i, j + 2] || firstMatch && memo[i + 1, j];
                    }
                    else
                    {
                        memo[i, j] = firstMatch && memo[i + 1, j + 1];
                    }
                }
            }

            return memo[0, 0];
        }
    }
}
