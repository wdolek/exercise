using System;

namespace Exercise.H4x0rR4nk.Staircase
{
    // https://www.hackerrank.com/challenges/staircase/problem
    public class Staircasator
    {
        static void staircase(int n)
        {
            for (var i = 0; i < n; i++)
            {
                var level = new String('#', i + 1);
                Console.WriteLine(level.PadLeft(n));
            }
        }
    }
}
