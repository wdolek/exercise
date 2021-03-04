using System;

namespace Exercise.H4x0rR4nk.DrawingBook
{
    // https://www.hackerrank.com/challenges/drawing-book/problem
    public class PageCounter
    {
        static int pageCount(int n, int p)
        {
            return Math.Min(
                p / 2,
                n / 2 - p / 2);
        }
    }
}
