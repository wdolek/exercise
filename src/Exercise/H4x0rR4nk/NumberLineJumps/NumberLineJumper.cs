namespace Exercise.H4x0rR4nk.NumberLineJumps
{
    // https://www.hackerrank.com/challenges/kangaroo/problem
    public class NumberLineJumper
    {
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            for (int jumps = 0, i1 = x1, i2 = x2; jumps < 10000; jumps++, i1 += v1, i2 += v2)
            {
                if (i1 == i2)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
