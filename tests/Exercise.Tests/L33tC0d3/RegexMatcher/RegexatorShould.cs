using Exercise.L33tC0d3.RegexMatcher;
using Xunit;

namespace Exercise.Tests.L33tC0d3.RegexMatcher
{
    public class RegexatorShould
    {
        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a.", true)]
        [InlineData("aa", "a*", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        public void DetermineWhetherInputMatchesPattern(string input, string pattern, bool expected)
        {
            var regexator = new Regexator();

            Assert.Equal(expected, regexator.IsMatch(input, pattern));
        }
    }
}
