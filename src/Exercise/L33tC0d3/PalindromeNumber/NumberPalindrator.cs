using System.Collections.Generic;

namespace Exercise.L33tC0d3.PalindromeNumber
{
    // https://leetcode.com/problems/palindrome-number/
    public sealed class NumberPalindrator
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0))
            {
                return false;
            }

            // split to digits
            var digits = new List<int>();
            while (x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }

            // check first half of list with second half
            for (var i = 0; i < digits.Count / 2; i++)
            {
                if (digits[i] != digits[digits.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindromeSolution(int x)
        {
            // taken from submitted answers
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            var result = 0;
            while (x > result)
            {
                result = (result * 10) + (x % 10);
                x /= 10;
            }

            return x == result || x == result / 10;
        }
    }
}
