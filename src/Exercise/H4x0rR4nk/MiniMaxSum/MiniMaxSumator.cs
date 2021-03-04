using System;
using System.Linq;

namespace Exercise.H4x0rR4nk.MiniMaxSum
{
    // https://www.hackerrank.com/challenges/mini-max-sum/problem
    public class MiniMaxSumator
    {
        static void miniMaxSum(int[] arr)
        {
            var ordered =
                arr.OrderBy(i => i)
                    .Select(i => (long)i)
                    .ToArray();

            Console.WriteLine(
                "{0} {1}",
                ordered.Take(4).Sum(),
                ordered.Skip(1).Sum());
        }
    }
}
