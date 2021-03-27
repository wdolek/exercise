﻿using System;
using System.Linq;

namespace Exercise.L33tC0d3.ValidSquare
{
    // https://leetcode.com/problems/valid-square/
    public sealed class SquareValidator
    {
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            // solution: https://leetcode.com/problems/valid-square/discuss/1115691
            var a = new Point(p1);
            var b = new Point(p2);
            var c = new Point(p3);
            var d = new Point(p4);

            int distAtoB = CalculateSquareDistance(ref a, ref b);
            int distAtoC = CalculateSquareDistance(ref a, ref c);
            int distAtoD = CalculateSquareDistance(ref a, ref d);
            int distBtoC = CalculateSquareDistance(ref b, ref c);
            int distBtoD = CalculateSquareDistance(ref b, ref d);
            int distCtoD = CalculateSquareDistance(ref c, ref d);

            if (distAtoB == 0 || distAtoC == 0 || distAtoD == 0 || distAtoB != distCtoD || distAtoC != distBtoD || distAtoD != distBtoC)
            {
                return false;
            }

            return distAtoB == distAtoC || distAtoB == distAtoD || distAtoC == distAtoD;
        }

        public bool ValidSquareApproach2(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var a = new Point(p1);
            var b = new Point(p2);
            var c = new Point(p3);
            var d = new Point(p4);

            Point[] p = new[] { a, b, c, d }
                .OrderBy(p => p)
                .ToArray();

            return CalculateSquareDistance(ref p[0], ref p[1]) != 0
                && CalculateSquareDistance(ref p[0], ref p[1]) == CalculateSquareDistance(ref p[1], ref p[3])
                && CalculateSquareDistance(ref p[1], ref p[3]) == CalculateSquareDistance(ref p[3], ref p[2])
                && CalculateSquareDistance(ref p[3], ref p[2]) == CalculateSquareDistance(ref p[2], ref p[0])
                && CalculateSquareDistance(ref p[0], ref p[3]) == CalculateSquareDistance(ref p[1], ref p[2]);
        }

        public bool ValidSquareApproach3(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var a = new Point(p1);
            var b = new Point(p2);
            var c = new Point(p3);
            var d = new Point(p4);

            static bool IsSquare(ref Point p1, ref Point p2, ref Point p3, ref Point p4) =>
                CalculateSquareDistance(ref p1, ref p2) > 0
                && CalculateSquareDistance(ref p1, ref p2) == CalculateSquareDistance(ref p2, ref p3)
                && CalculateSquareDistance(ref p2, ref p3) == CalculateSquareDistance(ref p3, ref p4)
                && CalculateSquareDistance(ref p3, ref p4) == CalculateSquareDistance(ref p4, ref p1)
                && CalculateSquareDistance(ref p1, ref p3) == CalculateSquareDistance(ref p2, ref p4);

            return IsSquare(ref a, ref b, ref c, ref d)
                || IsSquare(ref a, ref c, ref b, ref d)
                || IsSquare(ref a, ref b, ref d, ref c);
        }

        // Fails on input: p1 = { 1, 1 }, p2 = { 0, 1 }, p3 = { 1, 2 }, p4 = { 0, 0 }
        public bool ValidSquare_Fail(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var a = new Point(p1);
            var b = new Point(p2);
            var c = new Point(p3);
            var d = new Point(p4);

            // calculate (square) distance of all points from point `a`:
            // d   c
            // | /
            // a - b
            var distB = CalculateSquareDistance(ref a, ref b);
            var distC = CalculateSquareDistance(ref a, ref c);
            var distD = CalculateSquareDistance(ref a, ref d);

            if (distB == 0 || distC == 0 || distD == 0)
            {
                return false;
            }

            // 1: c^2 = a^2 + b^2
            // 2: c^2 = a^2 + a^2 = 2 * a^2 // for square, a = b
            // 3: c   = sqrt(2 * a^2) = sqrt(2) * sqrt(a^2) = sqrt(2) * a
            // NB! we are already using square lengths

            // d   c
            // | /
            // a - b
            if (distB == distD
                && 2 * distB == distC
                && 2 * CalculateSquareDistance(ref b, ref c) == CalculateSquareDistance(ref b, ref d))
            {
                return true;
            }

            // d   b
            // | /
            // a - c
            if (distC == distD
                && 2 * distC == distB
                && 2 * CalculateSquareDistance(ref c, ref b) == CalculateSquareDistance(ref c, ref d))
            {
                return true;
            }

            // c   d
            // | /
            // a - b
            if (distB == distC
                && 2 * distB == distD
                && 2 * CalculateSquareDistance(ref b, ref d) == CalculateSquareDistance(ref b, ref c))
            {
                return true;
            }

            return false;
        }

        private static int CalculateSquareDistance(ref Point p, ref Point q)
        {
            var deltaX = p.X - q.X;
            var deltaY = p.Y - q.Y;

            // dp^2 + dq^2
            return (int)(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }

        private readonly struct Point : IComparable<Point>
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point(int[] coords)
                : this(coords[0], coords[1])
            {
            }

            public int X { get; }
            public int Y { get; }

            public int CompareTo(Point other)
            {
                return this.X == other.X
                    ? this.Y - other.Y
                    : this.X - other.X;
            }
        }
    }
}
