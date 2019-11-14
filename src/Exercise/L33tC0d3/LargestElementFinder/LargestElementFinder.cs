using System.Linq;

namespace Exercise.L33tC0d3.LargestElementFinder
{
    // https://leetcode.com/problems/kth-largest-element-in-an-array/
    public sealed class LargestElementFinder
    {
        public int FindKthLargest(int[] nums, int k) =>
            nums.OrderByDescending(v => v)
                .Skip(k - 1)
                .First();
    }
}
