namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{
    public class EPalindrome
    {
        public bool IsPalindrome(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = head.next;
                fast = head.next.next;
            }

            var secondHalfHead = slow.next;
            slow.next = null;
            ListNode previous = null;
            var current = secondHalfHead;
            var next = secondHalfHead.next;
            while (current != null)
            {
                current.next = previous;
                previous = current;
                current = current.next;
            }

            var check1 = head;
            var check2 = secondHalfHead;
            bool palindrome = true;
            while (secondHalfHead != null)
            {
                if(check1.val != check2.val)
                {
                    palindrome = false;
                    break;
                }

                check1 = check1.next;
                check2 = check2.next;
            }

            return palindrome;
        }
    }
}