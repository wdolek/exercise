using Exercise.L33tC0d3.RaceCar;
using Xunit;

namespace Exercise.Tests.L33tC0d3.RaceCar;

public class RaceCarTargetatorShould
{
    [Theory]
    [InlineData(3, 2)]
    [InlineData(6, 5)]
    [InlineData(4, 5)]
    public void CalculateMinimumStepsToReachTarget(int target, int expectedSteps)
    {
        // arrange
        var targetator = new RaceCarTargetator();
        var minimumSteps = targetator.Racecar(target);

        // assert
        Assert.Equal(expectedSteps, minimumSteps);
    }
}
