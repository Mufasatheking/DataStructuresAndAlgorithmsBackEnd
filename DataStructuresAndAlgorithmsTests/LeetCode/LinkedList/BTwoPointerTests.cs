namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) {
                 val = x;
                 next = null;
            }
     }
    public class BTwoPointerTests
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int totalLength = 1;
            var lengthNode = head;
            while (lengthNode.next != null)
            {
                lengthNode = lengthNode.next;
                totalLength++;
            }

            var previousToDeleteNode = head;
            int index = 1;
            Console.WriteLine(totalLength);
            Console.WriteLine(totalLength-n);
            if (0 == (totalLength - n))
            {
                if (head.next != null)
                    return head.next;
                return null;
            }
            while (index < (totalLength-n))
            {
                previousToDeleteNode = previousToDeleteNode.next;
                index++;
            }
            Console.WriteLine(previousToDeleteNode.val);
            if (previousToDeleteNode.next.next == null)
            {
                previousToDeleteNode.next = null;
            }
            else
            {
                previousToDeleteNode.next = previousToDeleteNode.next.next;
            }
            return head;
        }
        
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var headALength = 1;
            var nodeA = headA;
            var headBLength = 1;
            var nodeB = headB;
            while (nodeA.next != null)
            {
                nodeA = nodeA.next;
                headALength++;
            }
            while (nodeB.next != null)
            {
                nodeB = nodeB.next;
                headBLength++;
            }

            var intersectLength = Math.Abs(headALength - headBLength);

            var indexA = 0;
            var indexB = 0;
            Console.WriteLine($"headALength:{headALength}");
            Console.WriteLine($"headBLength:{headBLength}");
            Console.WriteLine($"intersectLength:{intersectLength}");
            if (headALength > headBLength)
            {
                while (indexA < (intersectLength))
                {
                    headA = headA.next;
                    indexA++;
                }
            }
            if (headALength < headBLength)
            {
                while (indexB < (intersectLength))
                {
                    headB = headB.next;
                    indexB++;
                }
            }
            Console.WriteLine($"headA:{headA.val}");
            Console.WriteLine($"headB:{headB.val}");
            if (headA == headB)
                return headA;
            while (headA.next != null && headB.next != null)
            {
                headA = headA.next;
                headB = headB.next;
                if (headA == headB)
                    return headA;
            }
            return null;
        }
        public ListNode DetectCycle(ListNode head) {
            if(head == null || head.next == null) 
                return null;
    
            ListNode slow = head;
            ListNode fast = head;

            // Step 1: Detect the cycle
            while(true){
                if(fast == null || fast.next == null)
                    return null; // No cycle
                slow = slow.next;
                fast = fast.next.next;

                if(slow == fast) // Cycle detected
                    break;
            }

            // Step 2: Find the start of the cycle
            fast = head; // Reset the fast pointer to the head
            while(slow != fast){
                slow = slow.next;
                fast = fast.next;
            }

            return slow; // This is the start of the cycle
        }
    }
}
