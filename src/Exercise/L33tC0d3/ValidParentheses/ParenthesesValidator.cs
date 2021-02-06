using System.Collections.Generic;

namespace Exercise.L33tC0d3.ValidParentheses
{
    // https://leetcode.com/problems/valid-parentheses/
    public class ParenthesesValidator
    {
        public bool IsValid(string s)
        {
            var brackets = new Stack<char>();
            foreach (var bracket in s)
            {
                if (IsOpening(bracket))
                {
                    brackets.Push(bracket);
                    continue;
                }

                if (brackets.Count == 0)
                {
                    return false;
                }

                var last = brackets.Pop();
                if (!IsPair(last, bracket))
                {
                    return false;
                }
            }

            return brackets.Count == 0;
        }

        private bool IsOpening(char symbol)
        {
            return symbol == '('
                || symbol == '{'
                || symbol == '[';
        }

        private bool IsPair(char left, char right)
        {
            return (left == '(' && right == ')')
                || (left == '{' && right == '}')
                || (left == '[' && right == ']');
        }
    }
}
