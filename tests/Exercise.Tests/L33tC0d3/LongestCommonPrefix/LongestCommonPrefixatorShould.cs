using Exercise.L33tC0d3.LongestCommonPrefix;
using Xunit;

namespace Exercise.Tests.L33tC0d3.LongestCommonPrefix
{
    public class LongestCommonPrefixatorShould
    {
        [Theory]
        [InlineData(new[] { "flower", "flow", "flight" }, "fl")]
        [InlineData(new[] { "dog", "racecar", "car" }, "")]
        [InlineData(new[] { "test" }, "test")]
        [InlineData(new[] { "", "" }, "")]
        [InlineData(new[] { "ab", "a" }, "a")]
        [InlineData(new[] { "a", "ac" }, "a")]
        [InlineData(new string[0], "")]
        [InlineData(null!, "")]
        public void ReturnShortestCommonPrefix(string[]? strs, string expected)
        {
            var prefixator = new LongestCommonPrefixator();
            var shortestPrefix = prefixator.LongestCommonPrefix(strs);

            Assert.Equal(expected, shortestPrefix);
        }
    }
}
