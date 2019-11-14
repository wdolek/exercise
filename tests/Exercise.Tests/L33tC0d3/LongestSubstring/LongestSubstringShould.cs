using System.Collections.Generic;
using Xunit;
using Substringator = Exercise.L33tC0d3.LongestSubstring.LongestSubstring;

namespace Exercise.Tests.L33tC0d3.LongestSubstring
{
    public sealed class LongestSubstringShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnExpectedLengthOfLongestSubstring(string s, int expectedLength)
        {
            var substr = new Substringator();
            var result = substr.LengthOfLongestSubstring(s);

            Assert.Equal(expectedLength, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { "abcabcbb", 3 };
            yield return new object[] { "bbbbb", 1 };
            yield return new object[] { "pwwkew", 3 };
            yield return new object[] { " ", 1 };
            yield return new object[] { "aab", 2 };
            yield return new object[] { "dvdf", 3 };
        }
    }
}
