using System.Collections.Generic;
using System.Linq;
using Exercise.L33tC0d3.RemoveDuplicatesFromSortedArray;
using Xunit;

namespace Exercise.Tests.L33tC0d3.RemoveDuplicatesFromSortedArray
{
    public class DuplicateValueRemoverShould
    {
        [Theory]
        [InlineData(new[] { 1, 1, 2 })]
        [InlineData(new[] { 1, 1, 2, 2 })]
        [InlineData(new[] { 1, 1, 1, 2, 2, 2 })]
        [InlineData(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 })]
        public void DetectDuplicatesCorrectly(int[] nums)
        {
            var uniqueValues = new HashSet<int>(nums);

            var remover = new DuplicateValueRemover();
            var numOfUniqueValues = remover.RemoveDuplicates(nums);

            Assert.Equal(uniqueValues.Count, numOfUniqueValues);
            Assert.Equal(uniqueValues, nums.Take(numOfUniqueValues));
        }
    }
}
