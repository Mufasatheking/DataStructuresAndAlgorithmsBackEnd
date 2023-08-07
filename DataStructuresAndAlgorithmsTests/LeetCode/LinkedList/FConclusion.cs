namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{
    public class Node
    {
        public int val;
        public Node next;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
            next = null;
        }

        public Node(int _val, Node _next)
        {
            val = _val;
            next = _next;
        }
    }

    public class FConclusion
    {

        [Test]
        public void InsertTest()
        {
            var result = Insert(null, 1);
            Assert.IsTrue(true);
        }
        
        public Node Insert(Node head, int insertVal)
        {
            Node insert = new Node(insertVal);
            int maxVal = int.MinValue;
            int minVal = int.MaxValue;
            var foundMax = false;
            var foundMin = false;
            Node previous = null;
            Node current = head;
            Node next = head.next;
            ///3,4,5,1,2,
            var continueSearch = true;
            while (continueSearch)
            {
                if (current.val >= maxVal)
                {
                    maxVal = current.val;
                }
                if (current.val <= minVal)
                {
                    minVal = current.val;
                }
                if ((current.val >= insertVal && insertVal >= next.val) ||(current.val == maxVal && current.next.val==minVal))
                {
                    insert.next = current.next;
                    current.next = insert;
                    break;
                }

                current = current.next;
            }

            return insert;
        }
        [Test]
        public void MergeTwoListsTests()
        {
            // array for List 1
            int[] array1 = { 2 };
            // array for List 2
            int[] array2 = { 1 };

            // create List 1
            ListNode list1 = new ListNode(array1[0]);
            ListNode current = list1;
            for (int i = 1; i < array1.Length; i++)
            {
                current.next = new ListNode(array1[i]);
                current = current.next;
            }

            // create List 2
            ListNode list2 = new ListNode(array2[0]);
            current = list2;
            for (int i = 1; i < array2.Length; i++)
            {
                current.next = new ListNode(array2[i]);
                current = current.next;
            }

            var result = MergeTwoLists2(list1, list2);
            Assert.IsTrue(true);
        }

        public ListNode MergeTwoLists2(ListNode list1, ListNode list2)
        {
            ListNode prehead = new ListNode(-1);
            ListNode prev = prehead;

            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    prev.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    prev.next = list2;
                    list2 = list2.next;
                }
            }

            if (list1 == null)
            {
                prev.next = list2;
            }

            if (list2 == null)
            {
                prev.next = list1;
            }

            return prehead.next;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var current1 = list1;
            var current2 = list2;
            if (current1 == null && current2 == null)
                return null;
            if (current1 == null)
                return current2;
            if (current2 == null)
                return current1;
            ListNode current1Next = null;
            ListNode current2Next = null;
            ListNode head = null;
            ListNode previous = null;
            if (current1.val > current2.val)
            {
                head = current2;
            }
            else
            {
                head = current1;
            }

            int index = 1;

            while (current1 != null || current2 != null)
            {
                Console.WriteLine($"index:{index}");
                Console.WriteLine($"current1.val:{current1?.val}");
                Console.WriteLine($"current2.val:{current2?.val}");
                Console.WriteLine($"----");
                if (current1 == null && current2 == null)
                {
                    break;
                }

                if (current1 == null)
                {
                    Console.WriteLine("a");
                    previous.next = current2;
                    previous = current2;
                    current2 = current2.next;

                }
                else if (current2 == null)
                {
                    Console.WriteLine("b");
                    previous.next = current1;
                    previous = current1;
                    current1 = current1.next;

                }
                else if (current1.val > current2.val)
                {
                    Console.WriteLine("c");
                    if (current2.next != null)
                    {
                        while (current1.val >= current2.next.val)
                        {
                            current2Next = current2.next;
                            previous = current2;
                            current2 = current2Next;
                            if (current2.next == null)
                                break;
                        }
                    }

                    current2Next = current2.next;
                    current2.next = current1;
                    previous = current2;
                    current2 = current2Next;
                    Console.WriteLine($"current1.val:{current1?.val}");
                    Console.WriteLine($"current2.val:{current2?.val}");
                }
                else if (current2.val >= current1.val)
                {
                    Console.WriteLine("d");
                    Console.WriteLine($"current1.val:{current1?.val}");
                    Console.WriteLine($"current2.val:{current2?.val}");
                    if (current1.next != null)
                    {
                        while (current2.val >= current1.next.val)
                        {
                            current1Next = current1.next;
                            previous = current1;
                            current1 = current1Next;
                            if (current1.next == null)
                                break;
                        }
                    }

                    current1Next = current1.next;
                    current1.next = current2;
                    previous = current1;
                    current1 = current1Next;
                    Console.WriteLine($"current1.val:{current1?.val}");
                    Console.WriteLine($"current2.val:{current2?.val}");
                }

                Console.WriteLine($"");
                index++;
            }

            return head;
        }
    }
}