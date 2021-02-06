namespace Exercise.L33tC0d3.MergeTwoSortedLists
{
    // https://leetcode.com/problems/merge-two-sorted-lists/
    public class SortedListMergator
    {
        public ListNode? MergeTwoLists(ListNode l1, ListNode l2)
        {
            // new linked list for keeping result; root element won't be returned
            var temp = new ListNode();

            var current = temp;

            // copy reference to `l1` and `l2`
            // (not needed; just in case we can access original root element in memory)
            var first = l1;
            var second = l2;

            // while both lists have elements do merging
            while (first != null && second != null)
            {
                if (first.val <= second.val)
                {
                    current.next = first;
                    first = first.next;
                }
                else
                {
                    current.next = second;
                    second = second.next;
                }

                current = current.next;
            }

            // link rest of remaining linked list (if any)
            if (first != null)
            {
                current.next = first;
            }
            else if (second != null)
            {
                current.next = second;
            }

            return temp.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode? next;

            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
