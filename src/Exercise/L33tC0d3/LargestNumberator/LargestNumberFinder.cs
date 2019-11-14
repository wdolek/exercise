using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Exercise.L33tC0d3.LargestNumberator
{
    // https://leetcode.com/problems/largest-number/
    public sealed class LargestNumberFinder
    {
        public string LargestNumber(int[] nums)
        {
            if (nums.All(i => i == 0))
            {
                return "0";
            }

            // if input is:
            //  [3, 30, 34, 5, 9]
            //
            // simple sort (taking in consideration leading digit) will give us wrong result:
            //  "9 5 3 34 30"
            //
            // we need to compare pair as whole, so we instead get array sorted as:
            //  "9 5 34 3 30"
            var strs =
                nums.Select(i => i.ToString(CultureInfo.InvariantCulture))
                    .OrderByDescending(s => s, new NumberPairComparer());

            return string.Join("", strs);
        }

        private class NumberPairComparer : IComparer<string>
        {
            public int Compare(string x, string y) =>
                string.Compare(
                    x + y,
                    y + x,
                    StringComparison.Ordinal);
        }
    }
}
