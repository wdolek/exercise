using Exercise.L33tC0d3.WordBreak;
using Xunit;

namespace Exercise.Tests.L33tC0d3.WordBreak;

public class WordBreakerShould
{
    [Fact]
    public void EvaluateNonRepeatingStrings()
    {
        var breaker = new WordBreaker();
        var canBeSegmented = breaker.WordBreak("leetcode", ["leet", "code"]);

        Assert.True(canBeSegmented);
    }

    [Fact]
    public void EvaluateRepeatingStrings()
    {
        var breaker = new WordBreaker();
        var canBeSegmented = breaker.WordBreak("applepenapple", ["apple", "pen"]);

        Assert.True(canBeSegmented);
    }

    [Fact]
    public void IndicateNoSegmentation()
    {
        var breaker = new WordBreaker();
        var canBeSegmented = breaker.WordBreak("catsandog", ["cats", "dog", "sand", "and", "cat"]);

        Assert.False(canBeSegmented);
    }
}
