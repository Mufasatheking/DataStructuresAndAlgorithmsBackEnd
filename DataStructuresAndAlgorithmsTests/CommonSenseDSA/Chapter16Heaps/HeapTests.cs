namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter16Heaps
{
    public class Heap
    {
        private List<int> data;
        public Heap()
        {
            data = new List<int>();
        }
        public object RootNode
        {
            get { return data.FirstOrDefault(); }
        }
        public object LastNode
        {
            get { return data.LastOrDefault(); }
        }
        public int LeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        public int RightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        public int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        
        public void Insert(int value)
        {
            // Turn value into last node by inserting it at the end of the list:
            data.Add(value);

            // Keep track of the index of the newly inserted node:
            int newNodeIndex = data.Count - 1;

            // The following loop executes the "trickle up" algorithm.
    
            // If the new node is not in the root position,
            // and it's greater than its parent node:
            while (newNodeIndex > 0 && data[newNodeIndex] > data[ParentIndex(newNodeIndex)])
            {
                // Swap the new node with the parent node:
                int temp = data[ParentIndex(newNodeIndex)];
                data[ParentIndex(newNodeIndex)] = data[newNodeIndex];
                data[newNodeIndex] = temp;

                // Update the index of the new node:
                newNodeIndex = ParentIndex(newNodeIndex);
            }
        }
        public void Delete()
        {
            // We only ever delete the root node from a heap, so we
            // pop the last node from the list and make it the root node:
            data[0] = data.Last();
            data.RemoveAt(data.Count - 1);
  
            // Track the current index of the "trickle node":
            int trickleNodeIndex = 0;

            // The following loop executes the "trickle down" algorithm:
    
            // We run the loop as long as the trickle node has a child
            // that is greater than it:
            while (HasGreaterChild(trickleNodeIndex))
            {
                // Save larger child index in variable:
                int largerChildIndex = CalculateLargerChildIndex(trickleNodeIndex);

                // Swap the trickle node with its larger child:
                int temp = data[trickleNodeIndex];
                data[trickleNodeIndex] = data[largerChildIndex];
                data[largerChildIndex] = temp;

                // Update trickle node's new index:
                trickleNodeIndex = largerChildIndex;
            }
        }

        public bool HasGreaterChild(int index)
        {
            // We check whether the node at index has left and right
            // children and if either of those children are greater
            // than the node at index:
            return (LeftChildIndex(index) < data.Count && data[LeftChildIndex(index)] > data[index]) ||
                   (RightChildIndex(index) < data.Count && data[RightChildIndex(index)] > data[index]);
        }

        public int CalculateLargerChildIndex(int index)
        {
            // If there is no right child:
            if (RightChildIndex(index) >= data.Count)
            {
                // Return left child index:
                return LeftChildIndex(index);
            }

            // If right child value is greater than left child value:
            if (data[RightChildIndex(index)] > data[LeftChildIndex(index)])
            {
                // Return right child index:
                return RightChildIndex(index);
            }
            else // If the left child value is greater or equal to right child:
            {
                // Return the left child index:
                return LeftChildIndex(index);
            }
        }
    }
    
    public class HeapTests
    {
        
    }
}