namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{
    public class DOddEven
    {
        public ListNode OddEvenList(ListNode head)
        {
            var odd = head;
            var even = head.next;
            var evenHead = head.next;
          

            while (even != null && even.next != null)
            {
                odd.next = odd.next.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }
    }
}