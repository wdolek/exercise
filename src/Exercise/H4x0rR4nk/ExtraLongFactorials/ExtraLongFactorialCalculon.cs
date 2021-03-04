using System;
using System.Numerics;

namespace Exercise.H4x0rR4nk.ExtraLongFactorials
{
    // https://www.hackerrank.com/challenges/extra-long-factorials/problem
    public class ExtraLongFactorialCalculon
    {
        static void extraLongFactorials(int n)
        {
            var result = new BigInteger(n);
            for (var i = n - 1; i > 0; i--)
            {
                result = BigInteger.Multiply(result, new BigInteger(i));
            }

            Console.WriteLine(result);
        }
    }
}
