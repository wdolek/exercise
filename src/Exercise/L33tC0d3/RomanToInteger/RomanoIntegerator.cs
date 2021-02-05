using System.Collections.Generic;

namespace Exercise.L33tC0d3.RomanToInteger
{
    // https://leetcode.com/problems/roman-to-integer/
    public class RomanoIntegerator
    {
        private static readonly Dictionary<char, ushort> Literals =
            new Dictionary<char, ushort>
            {
                ['M'] = 1000,
                ['D'] = 500,
                ['C'] = 100,
                ['L'] = 50,
                ['X'] = 10,
                ['V'] = 5,
                ['I'] = 1,
            };

        public int RomanToInt(string s)
        {
            var result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var current = Literals[s[i]];
                var next = i < s.Length - 1
                    ? Literals[s[i + 1]]
                    : 0;

                if (current >= next)
                {
                    result += current;
                }
                else
                {
                    result += (next - current);
                    i += 1;
                }
            }

            return result;
        }
    }
}
