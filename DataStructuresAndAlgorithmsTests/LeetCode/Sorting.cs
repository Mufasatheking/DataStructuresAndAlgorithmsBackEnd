using DataStructuresAndAlgorithmsTests.LeetCode.LinkedList;

namespace DataStructuresAndAlgorithmsTests.LeetCode
{
    public class Sorting
    {
        [Test]
        public void InsertionSortListTest()
        {
            ListNode node3 = new ListNode(3);
            ListNode node2 = new ListNode(1, node3);
            ListNode node1 = new ListNode(2, node2);
            ListNode head = new ListNode(4, node1);
            var result = InsertionSortList(head);
        }
        public ListNode InsertionSortList(ListNode head)
        {
            int current = 0;

            ListNode sortedListHead = head;
            sortedListHead.next = null;
            ListNode previous = null;
            ListNode sortNode = head.next;
            ListNode next = sortNode.next;
            while(next!= null)
            {
                //Insert the Node
                ListNode previousInsert = null;
                ListNode currentInsert = sortedListHead;
                ListNode nextInsert = null;
                while (currentInsert != null)
                {
                    if (currentInsert.val > sortNode.val && previousInsert == null)
                    {
                        sortNode.next = currentInsert;
                        sortedListHead = sortNode;
                        break;
                    }
                    else if (currentInsert.val > sortNode.val && sortNode.val >= previousInsert.val)
                    {
                        sortNode.next = currentInsert.next;
                        previousInsert.next = sortNode;
                        break;
                    }
                    else if (currentInsert.next == null && sortNode.val >= currentInsert.val)
                    {
                        currentInsert.next = sortNode;
                        break;
                    }
                    else
                    {
                        previousInsert = currentInsert;
                        currentInsert = nextInsert;
                        nextInsert = nextInsert.next;
                    }
                }

                sortNode = next;
                next = next.next;
            }
            return sortedListHead;
        }
    }
}