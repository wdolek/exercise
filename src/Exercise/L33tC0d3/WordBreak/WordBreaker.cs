using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Exercise.L33tC0d3.WordBreak;

// https://leetcode.com/problems/word-break/ (139)
// solution: https://leetcode.com/problems/word-break/solutions/3834571/c-easy-to-understand-solution-beats-runtime-99-memory-28
public class WordBreaker
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        // dynamic programming; dp[i] = true if s[i..] can be broken into words in wordDict
        Span<bool> dp = stackalloc bool[s.Length + 1];
        dp[^1] = true;

        var inputSpan = s.AsSpan();

        // pass reference to the List's internal memory to speed up iteration (using marshalling),
        // or fallback to `.GetEnumerator()` and `.MoveNext()` if `wordDict` is not a List<T>
        // ---
        // NB! this is a micro-optimization; will perhaps speed up iteration, we still need to access heap for string value itself;
        //     benchmark to see if it's worth it ¯\_(ツ)_/¯
        if (wordDict is List<string> wordDictList)
        {
            var wordDictSpan = CollectionsMarshal.AsSpan(wordDictList);
            return WordBreakSpanImpl(ref dp, inputSpan, wordDictSpan);
        }

        return WordBreakEnumerableImpl(ref dp, inputSpan, wordDict);
    }

    private static bool WordBreakEnumerableImpl(ref Span<bool> dp, in ReadOnlySpan<char> s, IList<string> wordDict)
    {
        // iterate from the end of the string...
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // ... and try to match the word from provided dictionary
            foreach (var word in wordDict)
            {
                // current word won't fit into the remaining string, skip
                if (i + word.Length > s.Length)
                {
                    continue;
                }

                // current word matches, mark the current position and continue further
                var slice = s.Slice(i, word.Length);
                if (slice.Equals(word, StringComparison.Ordinal))
                {
                    dp[i] = dp[i + word.Length];
                    if (dp[i])
                    {
                        break;
                    }
                }
            }
        }

        return dp[0];
    }

    private static bool WordBreakSpanImpl(ref Span<bool> dp, in ReadOnlySpan<char> s, in Span<string> wordDict)
    {
        // iterate from the end of the string...
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // ... and try to match the word from provided dictionary
            foreach (var word in wordDict)
            {
                // current word won't fit into the remaining string, skip
                if (i + word.Length > s.Length)
                {
                    continue;
                }

                // current word matches, mark the current position and continue further
                var slice = s.Slice(i, word.Length);
                if (slice.Equals(word, StringComparison.Ordinal))
                {
                    dp[i] = dp[i + word.Length];
                    if (dp[i])
                    {
                        break;
                    }
                }
            }
        }

        return dp[0];
    }
}
