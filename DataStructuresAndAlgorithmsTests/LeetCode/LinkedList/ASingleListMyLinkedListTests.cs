namespace DataStructuresAndAlgorithmsTests.LeetCode.LinkedList
{
    public class Node{
        public int val {get;set;}
        public Node next {get;set;}
        public Node(int val){
            this.val = val;
        }
    }

    public class MyLinkedList {

        public Node Head {get;set;}
        public MyLinkedList() {
        
        }
    
        public int Get(int index) {
            int currIndex = 0;
            if (this.Head == null)
                return -1;
            var currNode = this.Head;
            while(currIndex < index)
            {
                if (currNode.next == null)
                    return -1;
                currNode = currNode.next;
                currIndex++;
            }
            return currNode.val;
        }
    
        public void AddAtHead(int val)
        {
            var head = new Node(val);
            if (this.Head != null)
            {
                head.next = this.Head;
            }
            this.Head = head;
        }
    
        public void AddAtTail(int val)
        {
            if (this.Head == null)
            {
                this.Head = new Node(val);
                return;
            }
            var currNode = this.Head;
            while (currNode.next != null)
            {
                currNode = currNode.next;
            }

            currNode.next = new Node(val);
        }
    
        public void AddAtIndex(int index, int val) {
            int currIndex = 0;
            var currNode = this.Head;
            if (index == 0)
            {
                this.AddAtHead(val);
                return;
            }
            if(this.Head == null)
                return;
            while(currIndex < index-1){
                if(currNode.next == null)
                    return;
                currNode = currNode.next;
                currIndex++;
            }
            var newNode = new Node(val);
            newNode.next = currNode.next;
            currNode.next = newNode;
        }
    
        public void DeleteAtIndex(int index) {
            if(this.Head == null)
                return;
            if (index == 0)
            {
                if( this.Head.next != null)
                    this.Head = this.Head.next;
                else if(this.Head.next == null)
                    this.Head = null;
                return;
            }
            int currIndex = 0;
            var currNode = this.Head;
            while(currIndex < index-1)
            {
                if (currNode.next == null)
                    return;
                currNode = currNode.next;
                currIndex++;
            }
            
            if(currNode.next != null)
            {
                currNode.next = currNode.next.next;
            }
            else
            {
                currNode.next = null;
            }
        }
    }

    
    public class ASingleListMyLinkedListTests
    {
        [Test]
        [TestCase(1, 3, new int[]{1,2}, 1,1,1)]
        public void RunCodeTest(int AddAtHead1, int AddAtTail1, int[] AddAtIndex1, int Get1, int DeleteAtIndex1, int Get2)
        {
            var myLinkedList = new MyLinkedList();
            
            myLinkedList.AddAtHead(AddAtHead1);
            
            myLinkedList.AddAtTail(AddAtTail1);
            
            myLinkedList.AddAtIndex(AddAtIndex1[0],AddAtIndex1[1]);
            
            var get1 =  myLinkedList.Get(Get1);
            
            myLinkedList.DeleteAtIndex(DeleteAtIndex1);
            
            var get2 = myLinkedList.Get(Get2);

            var aa = 2;
        }
        [Test]
        public void RunCodeTest2()
        {
            var myLinkedList = new MyLinkedList();
            
            myLinkedList.AddAtHead(1);

            myLinkedList.DeleteAtIndex(0);
            

            var aa = 2;
        }
        
        [Test]
        public void RunCodeTest3()
        {
            var myLinkedList = new MyLinkedList();
            
            myLinkedList.AddAtHead(7);
            myLinkedList.AddAtHead(2);
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtIndex(3,0);
            myLinkedList.DeleteAtIndex(2);            
            myLinkedList.AddAtHead(6);
            myLinkedList.AddAtTail(4);
            var get = myLinkedList.Get(4);
            myLinkedList.AddAtHead(4);
            myLinkedList.AddAtIndex(5,0);
            myLinkedList.AddAtHead(6);
            var aa = 2;
        }
        
        [Test]
        public void RunCodeTest4()
        {
            var myLinkedList = new MyLinkedList();
            
            myLinkedList.AddAtIndex(0,10);
            myLinkedList.AddAtIndex(0,20);
            myLinkedList.AddAtIndex(1,30);
            var get = myLinkedList.Get(0);
            var aa = 2;
        }
        
        [Test]
        public void RunCodeTest5()
        {
            var myLinkedList = new MyLinkedList();
            
            myLinkedList.AddAtTail(1);
            var get = myLinkedList.Get(0);
            var aa = 2;
        }
        
       [Test]
       public void RunCodeTest6()
       {
           var myLinkedList = new MyLinkedList();
            
           myLinkedList.AddAtHead(4);
           myLinkedList.Get(1);
           myLinkedList.AddAtHead(1);
           myLinkedList.AddAtHead(5);
           myLinkedList.DeleteAtIndex(3);
           myLinkedList.AddAtHead(7);
           myLinkedList.Get(3);
           myLinkedList.Get(3);
           myLinkedList.Get(3);
           myLinkedList.AddAtHead(1);
           myLinkedList.DeleteAtIndex(4);
           var aa = 2;
       }
       
       //["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get","get","deleteAtIndex","deleteAtIndex","get","deleteAtIndex","get"]
       //[[],[1],[3],[1,2],[1],[1],[1],[3],[3],[0],[0],[0],[0]]
       [Test]
       public void RunCodeTest7()
       {
           var myLinkedList = new MyLinkedList();

           myLinkedList.AddAtHead(1);
           myLinkedList.AddAtTail(3);
           myLinkedList.AddAtIndex(1, 2);
           myLinkedList.Get(1);
           myLinkedList.DeleteAtIndex(1);
           myLinkedList.Get(1);
           myLinkedList.Get(3);
           myLinkedList.DeleteAtIndex(3);
           myLinkedList.DeleteAtIndex(0);
           myLinkedList.Get(0);
           myLinkedList.DeleteAtIndex(0);
           myLinkedList.Get(0);

           var aa = 2;
       }
       
       [Test]
       public void RunCodeTest8()
       {
           var myLinkedList = new MyLinkedList();

           myLinkedList.AddAtHead(1);
           myLinkedList.AddAtTail(3);
           myLinkedList.AddAtIndex(1, 2);
           var get1 =myLinkedList.Get(1);
           myLinkedList.DeleteAtIndex(1);
           var get2 = myLinkedList.Get(1);
           var get3 =myLinkedList.Get(3);
           myLinkedList.DeleteAtIndex(3);
           myLinkedList.DeleteAtIndex(0);
           var get4 = myLinkedList.Get(0);
           myLinkedList.DeleteAtIndex(0);
           var get5 = myLinkedList.Get(0);

           var aa = 2;
       }
       
       [Test]
       public void RunCodeTest9()
       {
           var myLinkedList = new MyLinkedList();
           
           myLinkedList.AddAtHead(1);
           myLinkedList.AddAtTail(3);
           myLinkedList.AddAtIndex(3, 2);
           var aa = 2;
       }
       
       [Test]
       public void RunCodeTest10()
       {
           var myLinkedList = new MyLinkedList();
           
           myLinkedList.AddAtIndex(1,0);
           myLinkedList.Get(0);
           myLinkedList.AddAtIndex(3, 2);
           var aa = 2;
       }

       [Test]
       public void RunCodeTest11()
       {
           var myLinkedList = new MyLinkedList();

           myLinkedList.AddAtIndex(0, 10);
           myLinkedList.AddAtIndex(0, 30);
           myLinkedList.AddAtIndex(1, 20);
           myLinkedList.Get(0);
           var aa = 2;
       }
    }
}