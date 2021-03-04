using System;
using System.Linq;

namespace Exercise.H4x0rR4nk.BiggerIsGreater
{
    // https://www.hackerrank.com/challenges/bigger-is-greater/problem
    public class GreaterCalculon
    {
        static string biggerIsGreater(string w)
        {
            var nextPermutation = NextPermutation(w.ToArray());
            if (nextPermutation.Length == 0)
            {
                return "no answer";
            }

            return new String(nextPermutation);
        }

        // https://www.nayuki.io/page/next-lexicographical-permutation-algorithm
        private static char[] NextPermutation(char[] array)
        {
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
            {
                i--;
            }

            if (i <= 0)
            {
                return Array.Empty<char>();
            }

            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
            {
                j--;
            }

            char temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            j = array.Length - 1;
            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }

            return array;
        }
    }
}
