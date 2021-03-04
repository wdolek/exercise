using System;
using System.Collections.Generic;

namespace Exercise.H4x0rR4nk.DiagonalDifference
{
    // https://www.hackerrank.com/challenges/diagonal-difference/problem
    public class DiagonalDifferentator
    {
        public static int diagonalDifference(List<List<int>> arr)
        {
            var n = arr.Count;
            var cells = n * n;

            var primaryDiaglonal = 0;
            var primaryIncrement = n + 1;

            var secondaryDiagonal = 0;
            var secondaryIncrement = n - 1;

            for (int i = 0, j = secondaryIncrement; i < cells; i += primaryIncrement, j += secondaryIncrement)
            {
                var primaryIdx = i % n;
                primaryDiaglonal += arr[primaryIdx][primaryIdx];

                var secondaryRowIdx = j / n;
                var secondaryColIdx = j % n;
                secondaryDiagonal += arr[secondaryRowIdx][secondaryColIdx];
            }

            return Math.Abs(primaryDiaglonal - secondaryDiagonal);
        }
    }
}
