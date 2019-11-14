using System.Collections.Generic;
using System.Linq;

namespace Exercise.L33tC0d3.LargestTimeForDigits
{
    // https://leetcode.com/problems/largest-time-for-given-digits/submissions/
    public sealed class TimeDigitator
    {
        public string LargestTimeFromDigits(int[] A)
        {
            if (A == null || A.Length != 4)
            {
                return string.Empty;
            }

            // no possible hour, H*:**
            if (A.All(i => i > 2))
            {
                return string.Empty;
            }

            // no possible minute, **:M*
            if (A.All(i => i > 5))
            {
                return string.Empty;
            }

            var times = new List<(int Hours, int Minutes)>();

            // generate all valid combinations
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    for (var k = 0; k < 4; k++)
                    {
                        if (k == j || k == i)
                        {
                            continue;
                        }

                        // we can calculate `l` right away:
                        // - 6 is max sum of positions: 0 + 1 + 2 + 3
                        // - must not equal to any of `i`, `j` or `k`
                        //
                        // for (var l = 0; l < 4; l++) {
                        //     if (l == k || l == j || l == i) continue;
                        //     ...
                        // }
                        int l = 6 - i - j - k;

                        int hours = JoinDigits(A[i], A[j]);
                        int minutes = JoinDigits(A[k], A[l]);
                        if (IsValidTime(hours, minutes))
                        {
                            times.Add((hours, minutes));
                        }
                    }
                }
            }

            if (times.Count == 0)
            {
                return string.Empty;
            }

            // find the largest time
            (int h, int m) = times
                .OrderByDescending(t => GetTotalMinutes(t.Hours, t.Minutes))
                .First();

            return $"{h:D2}:{m:D2}";
        }

        private static int JoinDigits(in int tens, in int units) => tens * 10 + units;

        private static bool IsValidTime(in int hours, in int minutes) => hours < 24 && minutes < 60;

        private static int GetTotalMinutes(in int hours, in int minutes) => hours * 60 + minutes;
    }
}
