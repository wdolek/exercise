using System;

namespace Exercise.H4x0rR4nk.FormingMagicSquare
{
    // https://www.hackerrank.com/challenges/magic-square-forming/problem
    public class MagicSquareFormator
    {
        private static readonly int[][][] MagicBoxes = new int[][][]
        {
            new int[][] { new int[] {8, 1, 6}, new int[] {3, 5, 7}, new int[] {4, 9, 2} },
            new int[][] { new int[] {6, 1, 8}, new int[] {7, 5, 3}, new int[] {2, 9, 4} },
            new int[][] { new int[] {4, 9, 2}, new int[] {3, 5, 7}, new int[] {8, 1, 6} },
            new int[][] { new int[] {2, 9, 4}, new int[] {7, 5, 3}, new int[] {6, 1, 8} },
            new int[][] { new int[] {8, 3, 4}, new int[] {1, 5, 9}, new int[] {6, 7, 2} },
            new int[][] { new int[] {4, 3, 8}, new int[] {9, 5, 1}, new int[] {2, 7, 6} },
            new int[][] { new int[] {6, 7, 2}, new int[] {1, 5, 9}, new int[] {8, 3, 4} },
            new int[][] { new int[] {2, 7, 6}, new int[] {9, 5, 1}, new int[] {4, 3, 8} },
        };

        // -> https://www.hackerrank.com/challenges/magic-square-forming/forum/comments/280034
        static int formingMagicSquare(int[][] s)
        {
            var minCost = int.MaxValue;
            for (var k = 0; k < MagicBoxes.Length; k++)
            {
                var cost = 0;

                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        cost += Math.Abs(s[i][j] - MagicBoxes[k][i][j]);
                    }
                }

                if (cost < minCost)
                {
                    minCost = cost;
                }
            }

            return minCost;
        }
    }
}
