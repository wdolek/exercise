namespace Exercise.L33tC0d3.RemoveDuplicatesFromSortedArray
{
    public class DuplicateValueRemover
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            // start with 1: first value is unique for sure :)
            int numOfUniqueValues = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                // if {previous} != {current} ...
                if (nums[numOfUniqueValues - 1] != nums[i])
                {
                    // move {current} to {previous} ...
                    // (moves current value to last known position of duplicate)
                    nums[numOfUniqueValues] = nums[i];

                    // count +1 for unique number
                    ++numOfUniqueValues;
                }
            }

            return numOfUniqueValues;
        }
    }
}
