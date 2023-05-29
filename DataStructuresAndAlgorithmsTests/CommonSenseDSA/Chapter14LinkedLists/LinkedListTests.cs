namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter14LinkedLists
{
    public class Node
    {
        public object Data { get; set; }
        public Node NextNode { get; set; }

        public Node(object data)
        {
            this.Data = data;
        }
    }

    public class LinkedList
    {
        public Node FirstNode { get; set; }

        public LinkedList(Node firstNode)
        {
            this.FirstNode = firstNode;
        }
        
        public object Read(int index)
        {
            // We begin at the first node of the list:
            Node currentNode = this.FirstNode;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                // We keep following the links of each node until we get to the
                // index we're looking for:
                currentNode = currentNode.NextNode;
                currentIndex += 1;

                // If we're past the end of the list, that means the
                // value cannot be found in the list, so return null:
                if (currentNode == null)
                {
                    return null;
                }
            }

            // At this point, currentNode is the node at the desired index:
            return currentNode.Data;
        }
        
        public int? IndexOf(object value)
        {
            // We begin at the first node of the list:
            Node currentNode = this.FirstNode;
            int currentIndex = 0;

            while (currentNode != null)
            {
                // If we find the data we're looking for, we return it:
                if (currentNode.Data.Equals(value))
                {
                    return currentIndex;
                }

                // Otherwise, we move on the next node:
                currentNode = currentNode.NextNode;
                currentIndex += 1;
            }

            // If we get through the entire list without finding the data, we return null:
            return null;
        }
        
        public void InsertAtIndex(int index, object value)
        {
            // We create the new node with the provided value:
            Node newNode = new Node(value);

            // If we are inserting at the beginning of the list:
            if (index == 0)
            {
                // Have our new node link to what was the first node:
                newNode.NextNode = this.FirstNode;
                // Establish that our new node is now the list's first node:
                this.FirstNode = newNode;
                return;
            }

            // If we are inserting anywhere other than the beginning:

            Node currentNode = this.FirstNode;
            int currentIndex = 0;

            // First, we access the node immediately before where the new node will go:
            while (currentIndex < (index - 1))
            {
                currentNode = currentNode.NextNode;
                currentIndex += 1;
            }

            // Have the new node link to the next node:
            newNode.NextNode = currentNode.NextNode;

            // Modify the link of the previous node to point to our new node:
            currentNode.NextNode = newNode;
        }
        public void DeleteAtIndex(int index)
        {
            // If we are deleting the first node:
            if (index == 0)
            {
                // Simply set the first node to be what is currently the second node:
                this.FirstNode = this.FirstNode.NextNode;
                return;
            }

            Node currentNode = this.FirstNode;
            int currentIndex = 0;

            // First, we find the node immediately before the one we want to delete and call it currentNode:
            while (currentIndex < (index - 1))
            {
                currentNode = currentNode.NextNode;
                currentIndex += 1;
            }

            // We find the node that comes after the one we're deleting:
            Node nodeAfterDeletedNode = currentNode.NextNode.NextNode;

            // We change the link of the currentNode to point to the nodeAfterDeletedNode, 
            // leaving the node we want to delete out of the list:
            currentNode.NextNode = nodeAfterDeletedNode;
        }
        
        /*Add a method to the classic LinkedList class that prints all the elements of the list.*/
        public void PrintAll()
        {
            Node currentNode = this.FirstNode;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.NextNode;
            }
        }
        
        /*Add a method to the classic LinkedList class that returns the last element from the list.
         Assume you don’t know how many elements are in the list.*/
        public void PrintLast()
        {
            Node currentNode = this.FirstNode;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }
            
            Console.WriteLine(currentNode.Data);
        }
        
        /*Here’s a tricky one. Add a method to the classic LinkedList class that reverses the list.
         That is, if the original list is A -> B -> C, all of the list’s links should change so that C -> B -> A.*/
        
        public Node ReverseLinkedListRecursive(Node node)
        {
            if (node.NextNode == null)
            {
                FirstNode = node;
                return node;
            }

            var ret = ReverseLinkedListRecursive(node.NextNode);
            ret.NextNode = node;
            node.NextNode = null;
            return node;
        }

        public void DeleteMiddleNode(Node node)
        {
            node.Data = node.NextNode.Data;
            node.NextNode = node.NextNode.NextNode;
        }

    }
    public class LinkedListTests
    {
        public LinkedListTests()
        {
            var node_1 = new Node("once");
            var node_2 = new Node("upon");
            var node_3 = new Node("a");
            var node_4 = new Node("time");
            node_1.NextNode = node_2;
            node_2.NextNode = node_3;
            node_3.NextNode = node_4;
        }

        [Test]
        public void ReverseLinkedListTest()
        {
            var node_1 = new Node("once");
            var node_2 = new Node("upon");
            var node_3 = new Node("a");
            var node_4 = new Node("time");
            node_1.NextNode = node_2;
            node_2.NextNode = node_3;
            node_3.NextNode = node_4;
            var linkedList = new LinkedList(node_1);
            var reversedList = linkedList.ReverseLinkedListRecursive(node_1);
            var g = 5;
        }
    }
}