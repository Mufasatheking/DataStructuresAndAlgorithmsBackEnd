namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            var findingHead = true;
            while (findingHead)
            {
                if (head.val == val)
                {
                    if (head.next == null)
                        return null;
                    head = head.next;
                }
                else
                {
                    findingHead = false;
                }
            }

            var current = head;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
            }

            return head;
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;
            if (head.next.next == null)
            {
                var next2 = head.next;
                next2.next = head;
                head.next = null;
                return next2;
            }

            var previous = head;
            var current = head.next;
            head.next = null;
            while (current.next != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            Console.WriteLine(previous.val);
            Console.WriteLine(current.val);

            current.next = previous;
            return current;

        }
    }
}