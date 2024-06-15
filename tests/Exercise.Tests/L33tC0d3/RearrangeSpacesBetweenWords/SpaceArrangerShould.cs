using Exercise.L33tC0d3.RearrangeSpacesBetweenWords;
using Xunit;

namespace Exercise.Tests.L33tC0d3.RearrangeSpacesBetweenWords;

public class SpaceArrangerShould
{
    [Fact]
    public void RearrangeSpacesWithoutTrailingSpace()
    {
        // act
        var arranger = new SpaceArranger();
        var result = arranger.ReorderSpaces("  this   is  a sentence ");

        // assert
        Assert.Equal("this   is   a   sentence", result);
    }

    [Fact]
    public void RearrangeSpacesWithTrailingSpace()
    {
        // act
        var arranger = new SpaceArranger();
        var result = arranger.ReorderSpaces(" practice   makes   perfect");

        // assert
        Assert.Equal("practice   makes   perfect ", result);
    }
}
