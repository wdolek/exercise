namespace LC.FirstLastPosition
{
    // https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    public class FirstLastPositionFinder
    {
        private static readonly int[] EmptyResult = { -1, -1 };

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return EmptyResult;
            }

            // aim for O(log n)
            return new[]
            {
                FindLowerIndex(nums, target),
                FindUpperIndex(nums, target)
            };
        }

        public int[] SearchRangeLinear(int[] nums, int target)
        {
            var found = false;
            var startPos = -1;
            var endPos = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (!found)
                    {
                        startPos = i;
                        found = true;
                    }

                    endPos = i;
                }

                if (found && nums[i] != target)
                {
                    break;
                }
            }

            return new [] { startPos, endPos };
        }

        private static int FindLowerIndex(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                // [ 0,  1,  2,  3,  4,  5 ]
                //   ^       ^           ^
                //   start   pivot       end
                var pivot = start + ((end - start) / 2);
                if (nums[pivot] < target)
                {
                    start = pivot + 1;
                }
                else
                {
                    end = pivot;
                }
            }

            return nums[start] == target
                ? start
                : -1;
        }

        private static int FindUpperIndex(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                // [ 0,  1,  2,  3,  4,  5 ]
                //   ^           ^       ^
                //   start       pivot   end
                var pivot = start + ((end - start + 1) / 2);
                if (nums[pivot] > target)
                {
                    end = pivot - 1;
                }
                else
                {
                    start = pivot;
                }
            }

            return nums[start] == target
                ? start
                : -1;
        }
    }
}
