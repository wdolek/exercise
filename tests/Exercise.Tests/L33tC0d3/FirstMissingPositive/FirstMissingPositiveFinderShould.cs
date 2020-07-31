using System.Collections.Generic;
using Exercise.L33tC0d3.FirstMissingPositive;
using Xunit;

namespace Exercise.Tests.L33tC0d3.FirstMissingPositive
{
    public sealed class FirstMissingPositiveFinderShould
    {
        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositive(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositive(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithBitArray(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithBitArray(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithoutExtraMemory(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithoutExtraMemory(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithoutExtraMemoryUsingAny(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithoutExtraMemoryUsingAny(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithMinMax(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithMinMax(nums);

            Assert.Equal(expectedNumber, result);
        }

        public static IEnumerable<object[]> GenerateInput()
        {
            yield return new object[] { new[] { 1, 2, 0 }, 3 };
            yield return new object[] { new[] { 3, 4, -1, 1 }, 2 };
            yield return new object[] { new[] { 7, 8, 9, 11, 12 }, 1 };
            yield return new object[] { new[] { 1 }, 2 };

            // complete sequence 1..9
            yield return new object[] { new[] { 2, 4, 6, 8, 1, 3, 5, 7, 9 }, 10 };

            // no positive numbers at all
            yield return new object[] { new[] { -1, -2, -3 }, 1 };

            // values containing some crazy values
            yield return new object[] { new[] { -999, 999, 1, 2, 3, 4, 5, 6 }, 7 };
            yield return new object[] { new[] { 999, -999, 1 }, 2 };
        }
    }
}
