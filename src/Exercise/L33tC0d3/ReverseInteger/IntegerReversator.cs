using System;

namespace Exercise.L33tC0d3.ReverseInteger
{
    // https://leetcode.com/problems/reverse-integer/
    public sealed class IntegerReversator
    {
        public int Reverse(int x)
        {
            var result = 0;
            try
            {
                while (x != 0)
                {
                    result = checked((result * 10) + (x % 10));
                    x /= 10;
                }
            }
            catch (OverflowException)
            {
                return 0;
            }

            return result;
        }
    }
}
