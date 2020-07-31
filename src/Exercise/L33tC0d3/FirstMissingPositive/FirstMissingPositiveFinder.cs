using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.L33tC0d3.FirstMissingPositive
{
    // https://leetcode.com/problems/first-missing-positive/
    public sealed class FirstMissingPositiveFinder
    {
        public int FirstMissingPositive(int[] nums)
        {
            // turn input to set for better lookup, creating of set: O(n)
            var set = new HashSet<int>(nums);

            // for each: O(n), lookup: O(1)
            for (var i = 1; i <= set.Count + 1; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithBitArray(int[] nums)
        {
            // find max positive value: O(n)
            var max = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
            }

            // no positive number found, first non-negative is 1
            if (max == 0)
            {
                return 1;
            }

            // +1 for ignoring `0`
            // +1 for extra integer at the end of sequence
            var bitArray = new BitArray(max + 2);

            // create map of positive ints within given array: O(n)
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 1)
                {
                    continue;
                }

                bitArray[nums[i]] = true;
            }

            // find first index set to false: O(n)
            // (start from 1, index 0 is always false (see above))
            for (var i = 1; i < bitArray.Length; i++)
            {
                if (!bitArray[i])
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithoutExtraMemory(int[] nums)
        {
            // iterate from 1 .. (n + 1), for each run `Count` O(n) * O(n)
            for (var i = 1; i <= nums.Length + 1; i++)
            {
                var numOfIs = nums.Count(v => v == i);
                if (numOfIs == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithoutExtraMemoryUsingAny(int[] nums)
        {
            // iterate from 1 .. (n + 1), for each run `Count` O(n) * O(n)
            for (var i = 1; i <= nums.Length + 1; i++)
            {
                if (!nums.Any(v => v == i))
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithMinMax(int[] nums)
        {
            var min = int.MaxValue;
            var max = 0;

            // determine minimum and maximum values
            for (var i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (n > 0 && n < min)
                {
                    min = n;
                }

                if (n > max)
                {
                    max = n;
                }
            }

            // we haven't found any positive number
            if (max == 0)
            {
                return 1;
            }

            // if minimal positive value is [2,), first missing is just 1
            if (min > 1)
            {
                return 1;
            }

            // minimal positive value is 1, we need to find first missing number in sequence
            for (var n = min; n <= max; n++)
            {
                var found = false;
                for (var i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == n)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return n;
                }
            }

            // we haven't found missing number within sequence, so it must be max + 1
            return max + 1;
        }
    }
}
