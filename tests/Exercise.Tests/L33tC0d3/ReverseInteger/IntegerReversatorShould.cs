using Exercise.L33tC0d3.ReverseInteger;
using Xunit;

namespace Exercise.Tests.L33tC0d3.ReverseInteger
{
    public class IntegerReversatorShould
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(1534236469, 0)]
        public void ReverseNumberCorrectly(int input, int expected)
        {
            var reversator = new IntegerReversator();

            Assert.Equal(expected, reversator.Reverse(input));
        }
    }
}
