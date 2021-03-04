namespace Exercise.H4x0rR4nk.DivisibleSumPairs
{
    // https://www.hackerrank.com/challenges/divisible-sum-pairs/problem
    public class SumPairDivisblator
    {
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            var bucket = new int[k];
            var count = 0;

            foreach (var value in ar)
            {
                var modValue = value % k;
                count += bucket[(k - modValue) % k];
                bucket[modValue]++;
            }

            return count;
        }
    }
}
