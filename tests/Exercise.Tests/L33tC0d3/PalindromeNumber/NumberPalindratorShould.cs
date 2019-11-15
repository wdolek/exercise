using Exercise.L33tC0d3.PalindromeNumber;
using Xunit;

namespace Exercise.Tests.L33tC0d3.PalindromeNumber
{
    public class NumberPalindratorShould
    {
        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(123321, true)]
        [InlineData(123456, false)]
        [InlineData(102010, false)]
        [InlineData(0, true)]
        public void DetectNumberPalindrome(int input, bool expected)
        {
            var palindrator = new NumberPalindrator();

            Assert.Equal(expected, palindrator.IsPalindrome(input));
        }
    }
}
