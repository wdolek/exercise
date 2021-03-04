using System.Linq;

namespace Exercise.H4x0rR4nk.SimpleArraySum
{
    // https://www.hackerrank.com/challenges/simple-array-sum/problem
    public class SimpleArraySumator
    {
        static int simpleArraySum(int[] ar)
        {
            return ar.Sum();
        }

        static int simpleArraySumLinqLess(int[] ar)
        {
            var sum = 0;
            for (var i = ar.Length - 1; i >= 0; --i)
            {
                sum += ar[i];
            }

            return sum;
        }
    }
}
