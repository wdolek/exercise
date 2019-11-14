using Exercise.L33tC0d3.ContainerWithMostWatter;
using Xunit;

namespace Exercise.Tests.L33tC0d3.ContainerWithMostWatter
{
    public sealed class WaterContainerShould
    {
        [Theory]
        [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new[] { 1, 1 }, 1)]
        public void CalculateMaxArea(int[] height, int expectedArea)
        {
            var container = new WaterContainer();
            var result = container.MaxArea(height);

            Assert.Equal(expectedArea, result);
        }
    }
}
