using System;
using System.Linq;

namespace Exercise.H4x0rR4nk.PlusMinus
{
    // https://www.hackerrank.com/challenges/plus-minus/problem
    public class PlusMinusator
    {
        static void plusMinus(int[] arr)
        {
            var positiveNumbers = arr.Count(i => i > 0);
            Console.WriteLine("{0:0.000000}", (float)positiveNumbers / arr.Length);

            var negativeNumbers = arr.Count(i => i < 0);
            Console.WriteLine("{0:0.000000}", (float)negativeNumbers / arr.Length);

            var zeros = arr.Count(i => i == 0);
            Console.WriteLine("{0:0.000000}", (float)zeros / arr.Length);
        }
    }
}
