namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter14LinkedLists
{
    public class DoubleNode
    {
        public object Data { get; set; }
        public DoubleNode NextNode { get; set; }
        public DoubleNode PreviousNode { get; set; }

        public DoubleNode(object data)
        {
            this.Data = data;
        }
    }

    public class DoublyLinkedList
    {
        public DoubleNode FirstNode { get; set; }
        public DoubleNode LastNode { get; set; }

        public DoublyLinkedList(DoubleNode firstNode = null, DoubleNode lastNode = null)
        {
            this.FirstNode = firstNode;
            this.LastNode = lastNode;
        }
        
        public void InsertAtEnd(object value)
        {
            DoubleNode newNode = new DoubleNode(value);

            // If there are no elements yet in the linked list:
            if (this.FirstNode == null)
            {
                this.FirstNode = newNode;
                this.LastNode = newNode;
            }
            else // If the linked list already has at least one node:
            {
                newNode.PreviousNode = this.LastNode;
                this.LastNode.NextNode = newNode;
                this.LastNode = newNode;
            }
        }
        
        public DoubleNode RemoveFromFront()
        {
            DoubleNode removedNode = this.FirstNode;
            this.FirstNode = this.FirstNode.NextNode;
            return removedNode;
        }
        /*Add a method to the DoublyLinkedList class that prints all the elements of the list in reverse order.*/
        public void PrintAllReverse()
        {
            var currentNode = LastNode;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.PreviousNode;
            }
        }
    }
    
    public class Queue
    {
        public DoublyLinkedList Data { get; set; }

        public Queue()
        {
            this.Data = new DoublyLinkedList();
        }

        public void Enqueue(object element)
        {
            this.Data.InsertAtEnd(element);
        }

        public object Dequeue()
        {
            DoubleNode removedNode = this.Data.RemoveFromFront();
            return removedNode.Data;
        }

        public object Read()
        {
            if (this.Data.FirstNode == null)
            {
                return null;
            }
            return this.Data.FirstNode.Data;
        }
    }
    public class DoublyLinkedListTests
    {
        
    }
}