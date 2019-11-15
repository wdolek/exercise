using System.Collections.Generic;
using System.Linq;
using Exercise.L33tC0d3.AddTwoNumbers;
using Xunit;

namespace Exercise.Tests.L33tC0d3.AddTwoNumbers
{
    public class TwoNumberAdderShould
    {
        [Theory]
        [MemberData(nameof(GenerateData))]
        public void CalculateCorrectNumber(TwoNumberAdder.ListNode x, TwoNumberAdder.ListNode y, int expected)
        {
            var adder = new TwoNumberAdder();
            var result = adder.AddTwoNumbers(x, y);

            Assert.Equal(expected, ToInt(result));
        }

        public static TheoryData<TwoNumberAdder.ListNode, TwoNumberAdder.ListNode, int> GenerateData()
        {
            return new TheoryData<TwoNumberAdder.ListNode, TwoNumberAdder.ListNode, int>
            {
                // 342 + 465 = 807
                {
                    new TwoNumberAdder.ListNode(2).Add(4).Add(3),
                    new TwoNumberAdder.ListNode(5).Add(6).Add(4),
                    807
                },
                // 81 + 0 = 81
                {
                    new TwoNumberAdder.ListNode(1).Add(8),
                    new TwoNumberAdder.ListNode(0),
                    81
                }
            };
        }

        private static IEnumerable<int> Unwrap(TwoNumberAdder.ListNode node)
        {
            var tmp = node;
            while (tmp != null)
            {
                yield return tmp.val;
                tmp = tmp.next;
            }
        }

        private static int ToInt(TwoNumberAdder.ListNode node)
        {
            var nums = Unwrap(node).ToArray();
            var result = 0;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                result = nums[i] + result * 10;
            }

            return result;
        }
    }

    internal static class ListNodeExtensions
    {
        public static TwoNumberAdder.ListNode Add(this TwoNumberAdder.ListNode node, int i)
        {
            // iterate to last node
            var temp = node;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = new TwoNumberAdder.ListNode(i);

            return node;
        }
    }
}
