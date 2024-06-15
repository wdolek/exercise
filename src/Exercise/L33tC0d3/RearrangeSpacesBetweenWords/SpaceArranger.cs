using System;
using System.Linq;
using System.Text;

namespace Exercise.L33tC0d3.RearrangeSpacesBetweenWords;

// https://leetcode.com/problems/rearrange-spaces-between-words (1592)
public class SpaceArranger
{
    public string ReorderSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        var numOfSpaces = text.Count(c => c == ' ');
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // formula:
        // - number of spaces between words = <number of spaces> / <number of words - 1>
        // - trailing space(s) = <number of spaces> % <number of words - 1>
        var numOfSpacesBetweenWords = Math.DivRem(numOfSpaces, words.Length - 1, out var numOfTrailingSpaces);

        // 💡 alternatively `StringBuilder.AppendJoin` could be used
        var sb = new StringBuilder(text.Length);

        // append first word separately, then keep appending by starting with spaces
        // (this is to avoid if-condition checking whether to not append spaces after last word)
        sb.Append(words[0]);
        for (var i = 1; i < words.Length; i++)
        {
            sb.Append(' ', numOfSpacesBetweenWords);
            sb.Append(words[i]);
        }

        sb.Append(' ', numOfTrailingSpaces);

        return sb.ToString();
    }
}
