using Exercise.L33tC0d3.RomanToInteger;
using Xunit;

namespace Exercise.Tests.L33tC0d3.RomanToInteger
{
    public class RomanoIntegeratorShould
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void ReturnValidInteger(string roman, int expected)
        {
            var integerator = new RomanoIntegerator();
            Assert.Equal(expected, integerator.RomanToInt(roman));
        }
    }
}
