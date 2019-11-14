using System.Collections.Generic;

namespace Exercise.G33ks4G33ks.MaxNumFromNum
{
    // https://www.geeksforgeeks.org/find-maximum-number-can-formed-digits-number-reviewed/
    public class MaxNumberFinder
    {
        public int PrintMaxNum(int num)
        {
            // collect each digit from number
            var digits = new List<int>();
            var value = num;
            while (value > 0)
            {
                digits.Add(value % 10);
                value /= 10;
            }

            // sort digits from lowest to highest
            // NB! tis uses List<T>.Sort, not a LINQ one
            digits.Sort();

            // calculate the highest possible integer
            // - start with highest digits
            var result = 0;
            for (var i = digits.Count - 1; i >= 0; i--)
            {
                result = result * 10 + digits[i];
            }

            return result;
        }

        public int PrintMaxNumWithString(int num)
        {
            // GeeksForGeeks solution
            int[] count = new int[10];
            var str = num.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                count[str[i] - '0']++;
            }

            int result = 0;
            var multiplier = 1;

            for (int i = 0; i <= 9; i++)
            {
                while (count[i] > 0)
                {
                    result += i * multiplier;
                    count[i]--;
                    multiplier *= 10;
                }
            }

            return result;
        }
    }
}
