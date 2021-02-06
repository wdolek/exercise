using Exercise.L33tC0d3.ValidParentheses;
using Xunit;

namespace Exercise.Tests.L33tC0d3.ValidParentheses
{
    public class ParenthesesValidatorShould
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        public void ValidateParenthesesInGivenString(string s, bool expected)
        {
            var validator = new ParenthesesValidator();

            Assert.Equal(expected, validator.IsValid(s));
        }
    }
}
