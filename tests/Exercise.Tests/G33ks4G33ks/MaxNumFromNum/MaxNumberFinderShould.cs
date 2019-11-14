using Exercise.G33ks4G33ks.MaxNumFromNum;
using Xunit;

namespace Exercise.Tests.G33ks4G33ks.MaxNumFromNum
{
    public class MaxNumberFinderShould
    {
        [Theory]
        [MemberData(nameof(GenerateNumbers))]
        public void FindMaxPossibleNumber(int input, int expected)
        {
            var finder = new MaxNumberFinder();

            Assert.Equal(expected, finder.PrintMaxNum(input));
        }

        [Theory]
        [MemberData(nameof(GenerateNumbers))]
        public void FindMaxPossibleNumberUsingStr(int input, int expected)
        {
            var finder = new MaxNumberFinder();

            Assert.Equal(expected, finder.PrintMaxNumWithString(input));
        }

        public static TheoryData<int, int> GenerateNumbers() =>
            new TheoryData<int, int>
            {
                { 123, 321 },
                { 8754365, 8765543 },
                { 38293367, 98763332 },
                { 1203465, 6543210 }
            };
    }
}
