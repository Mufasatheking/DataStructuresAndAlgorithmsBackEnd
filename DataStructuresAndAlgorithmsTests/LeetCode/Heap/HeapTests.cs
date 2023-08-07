namespace DataStructuresAndAlgorithmsTests.LeetCode.Heap
{
    public class HeapTests
    {
        [Test]
        [TestCase(new int[]{3,2,3,1,2,4,5,5,6}, 4)]
        public void FindKthLargestTest(int[] nums, int k)
        {
            var first = new int[] { 9, 9, 9 };
            var second = new int[] { 1, 2, 3,4,5,6,7,7 };
        
            Array.Copy(second, first, second.Length);
            int largest = FindKthLargest(nums, k);
        }
        
        public int FindKthLargest(int[] nums, int k)
        {
            int[] heap = new int[k];
            Array.Copy(nums, heap, heap.Length);

            int startIndex = (heap.Length / 2) - 1;
            
            for (int i = startIndex; i >= 0; i--)
            {
                Heapify(heap, heap.Length, i);
            }
            for(int i = k; i<=nums.Length-1;i++)
            {
                var min = heap[0];
                var next = nums[i];
                if (next > min)
                {
                    heap[0] = nums[i];
                    Heapify(heap,heap.Length,0);
                }
            }
            return heap[0];
        }

        public void Heapify(int[] heap, int n, int i)
        {
            int smallest = i;
            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < n && heap[left] < heap[smallest])
            {
                smallest = left;
            }
            if (right < n && heap[right] < heap[smallest])
            {
                smallest = right;
            }

            if (smallest != i)
            {
                Swap(heap, i, smallest);
                Heapify(heap, n , smallest);
            }
        }
        
        public void Swap(int[] arr, int i, int j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        
    }
}