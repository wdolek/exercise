namespace Exercise.H4x0rR4nk.CountingValleys
{
    // https://www.hackerrank.com/challenges/counting-valleys/problem
    public class ValleyCounter
    {
        static int countingValleys(int n, string s)
        {
            var valleys = 0;
            var level = 0;
            foreach (var direction in s)
            {
                if (direction == 'U')
                {
                    ++level;
                }
                else
                {
                    --level;
                }

                if (direction == 'U' && level == 0)
                {
                    ++valleys;
                }
            }

            return valleys;
        }
    }
}
