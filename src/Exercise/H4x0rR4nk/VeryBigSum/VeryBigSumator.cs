namespace Exercise.H4x0rR4nk.VeryBigSum
{
    // https://www.hackerrank.com/challenges/a-very-big-sum/submissions
    public class VeryBigSumator
    {
        static long aVeryBigSum(long[] ar)
        {
            var result = 0L;

            for (var i = 0; i < ar.Length; i++)
            {
                unchecked
                {
                    result += ar[i];
                }
            }

            return result;
        }
    }
}
