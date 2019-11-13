using LC.LargestTimeForDigits;
using Xunit;

namespace LC.Tests.LargestTimeForDigits
{
    public class TimeDigitatorShould
    {
        [Theory]
        [InlineData(new [] { 1, 2, 3, 4 }, "23:41")]
        [InlineData(new [] { 2, 2, 2, 2 }, "22:22")]
        [InlineData(new [] { 9, 5, 0, 1 }, "19:50")]
        public void ReturnMaxTime(int[] input, string expected)
        {
            string result = new TimeDigitator().LargestTimeFromDigits(input);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(new [] { 3, 4, 5, 6 })]
        [InlineData(new [] { 6, 7, 8, 9 })]
        [InlineData(new [] { 0 })]
        [InlineData(new [] { 0, 1, 2, 3, 4 })]
        [InlineData(null)]
        public void ReturnEmpty(int[] input)
        {
            string result = new TimeDigitator().LargestTimeFromDigits(input);

            Assert.True(string.IsNullOrEmpty(result));
        }
    }
}
