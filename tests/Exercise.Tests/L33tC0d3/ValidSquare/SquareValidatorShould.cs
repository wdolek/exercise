using System.Collections.Generic;
using Exercise.L33tC0d3.ValidSquare;
using Xunit;

namespace Exercise.Tests.L33tC0d3.ValidSquare
{
    public class SquareValidatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateInput(int[] p1, int[] p2, int[] p3, int[] p4, bool isSquare)
        {
            var validator = new SquareValidator();
            Assert.Equal(isSquare, validator.ValidSquare(p1, p2, p3, p4));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateInputApproach2(int[] p1, int[] p2, int[] p3, int[] p4, bool isSquare)
        {
            var validator = new SquareValidator();
            Assert.Equal(isSquare, validator.ValidSquareApproach2(p1, p2, p3, p4));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateInputApproach3(int[] p1, int[] p2, int[] p3, int[] p4, bool isSquare)
        {
            var validator = new SquareValidator();
            Assert.Equal(isSquare, validator.ValidSquareApproach3(p1, p2, p3, p4));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateInputFinished(int[] p1, int[] p2, int[] p3, int[] p4, bool isSquare)
        {
            var validator = new SquareValidator();
            Assert.Equal(isSquare, validator.ValidSquareFinished(p1, p2, p3, p4));
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { new int[] { 0, 0 }, new int[] { 1, 1 }, new[] { 1, 0 }, new int[] { 0, 1 }, true };
            yield return new object[] { new int[] { 0, 0 }, new int[] { 1, 1 }, new[] { 1, 0 }, new int[] { 0, 12 }, false };
            yield return new object[] { new int[] { 1, 0 }, new int[] { -1, 0 }, new[] { 0, 1 }, new int[] { 0, -1 }, true };
            yield return new object[] { new int[] { 0, 1 }, new int[] { 1, 2 }, new[] { 0, 2 }, new int[] { 0, 0 }, false };
            yield return new object[] { new int[] { 0, 0 }, new int[] { 0, 0 }, new[] { 0, 0 }, new int[] { 0, 0 }, false };
            yield return new object[] { new int[] { 1, 1 }, new int[] { 0, 1 }, new[] { 1, 2 }, new int[] { 0, 0 }, false };
        }
    }
}
