using System;
using System.Collections.Generic;
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

            static bool IsSquare(ref Point p1, ref Point p2, ref Point p3, ref Point p4)
            {
                // perimeter
                int distP1toP2 = CalculateSquareDistance(ref p1, ref p2);
                int distP2toP3 = CalculateSquareDistance(ref p2, ref p3);
                int distP3toP4 = CalculateSquareDistance(ref p3, ref p4);
                int distP4toP1 = CalculateSquareDistance(ref p4, ref p1);

                // diagonals
                int distP1toP3 = CalculateSquareDistance(ref p1, ref p3);
                int distP2toP4 = CalculateSquareDistance(ref p2, ref p4);

                return distP1toP2 > 0
                    && distP1toP3 > distP1toP2
                    && distP1toP2 == distP2toP3
                    && distP2toP3 == distP3toP4
                    && distP3toP4 == distP4toP1
                    && distP1toP3 == distP2toP4;
            };

            return IsSquare(ref a, ref b, ref c, ref d)
                || IsSquare(ref a, ref c, ref b, ref d)
                || IsSquare(ref a, ref b, ref d, ref c);
        }

        public bool ValidSquareWithHashSet(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var a = new Point(p1);
            var b = new Point(p2);
            var c = new Point(p3);
            var d = new Point(p4);

            var distances = new HashSet<int>(
                new[]
                {
                    CalculateSquareDistance(ref a, ref b),
                    CalculateSquareDistance(ref a, ref c),
                    CalculateSquareDistance(ref a, ref d),
                    CalculateSquareDistance(ref b, ref c),
                    CalculateSquareDistance(ref b, ref d),
                    CalculateSquareDistance(ref c, ref d),
                });

            return !distances.Contains(0) && distances.Count == 2;
        }

        public bool ValidSquareFinished(int[] p1, int[] p2, int[] p3, int[] p4)
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

            // TODO: Refactor calls - just change order of inputs, see other solutions

            // d   c
            // | /
            // a - b
            if (distB == distD
                && CalculateSquareDistance(ref b, ref c) == CalculateSquareDistance(ref c, ref d)
                && 2 * distB == distC
                && 2 * CalculateSquareDistance(ref b, ref c) == CalculateSquareDistance(ref b, ref d))
            {
                return true;
            }

            // d   b
            // | /
            // a - c
            if (distC == distD
                && CalculateSquareDistance(ref c, ref b) == CalculateSquareDistance(ref b, ref d)
                && 2 * distC == distB
                && 2 * CalculateSquareDistance(ref c, ref b) == CalculateSquareDistance(ref c, ref d))
            {
                return true;
            }

            // c   d
            // | /
            // a - b
            if (distB == distC
                && CalculateSquareDistance(ref b, ref d) == CalculateSquareDistance(ref d, ref c)
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
