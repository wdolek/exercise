using System.Diagnostics;

namespace Exercise.L33tC0d3.AddTwoNumbers
{
    // https://leetcode.com/problems/add-two-numbers/
    public sealed class TwoNumberAdder
    {
        public ListNode? AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //   [2 -> 4 -> 3]
            // + [5 -> 6 -> 4]
            // ---------------
            //   [7 -> 0 -> 8]
            //
            // (342 + 465 = 807)

            var temp1 = l1;
            var temp2 = l2;

            var resultRoot = new ListNode(-1);
            var tempResult = resultRoot;

            var remainder = 0;

            while (temp1 != null || temp2 != null)
            {
                var sum = (temp1?.val).GetValueOrDefault()
                    + (temp2?.val).GetValueOrDefault()
                    + remainder;

                remainder = sum >= 10
                    ? 1
                    : 0;

                // store result
                tempResult.next = new ListNode(sum - (remainder * 10));
                tempResult = tempResult.next;

                // move to next if exists
                temp1 = temp1?.next;
                temp2 = temp2?.next;
            }

            // apply last remainder
            if (remainder > 0)
            {
                tempResult.next = new ListNode(remainder);
            }

            // strip first node
            return resultRoot.next;
        }

        [DebuggerDisplay("{val}")]
        public sealed class ListNode
        {
            public int val;
            public ListNode? next;

            public ListNode(int x)
            {
                val = x;
            }
        }
    }
}
