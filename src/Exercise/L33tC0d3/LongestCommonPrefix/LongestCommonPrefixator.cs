using System.Text;

namespace Exercise.L33tC0d3.LongestCommonPrefix
{
    // https://leetcode.com/problems/longest-common-prefix/
    public class LongestCommonPrefixator
    {
        public string LongestCommonPrefix(string[]? strs)
        {
            // base cases: no input or just single word
            if (strs is null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            // if reference word is empty, we won't find common prefix anyway
            var referenceWord = strs[0];
            if (referenceWord.Length == 0)
            {
                return "";
            }

            var pos = 0;
            var sb = new StringBuilder();

            while (true)
            {
                // if chars on position `pos` match, we finish loop and move to next position (handled by outer loop)
                // - iterate from end (avoid bound check)
                // - skip first word which we used as reference one
                for (var i = strs.Length - 1; i > 0; i--)
                {
                    var word = strs[i];

                    // we have reached end of shortes word in array (including reference word) -> break
                    // (`pos` matches array index, thus starts by 0)
                    if (referenceWord.Length == pos || word.Length == pos)
                    {
                        goto breaking_point;
                    }

                    // chars on current position don't match -> break
                    if (word[pos] != referenceWord[pos])
                    {
                        goto breaking_point;
                    }
                }

                sb.Append(referenceWord[pos]);
                ++pos;
            }

breaking_point:
            return sb.ToString();
        }
    }
}
