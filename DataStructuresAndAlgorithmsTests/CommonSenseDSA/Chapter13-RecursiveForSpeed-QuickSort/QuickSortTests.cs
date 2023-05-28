namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter13_RecursiveForSpeed_QuickSort
{
    public class QuickSortTests
    {
         public int[] Array { get; }

    public QuickSortTests(int[] array)
    {
        Array = array;
    }

    public void QuickSort(int leftIndex, int rightIndex)
    {
        // Base case: the subarray has 0 or 1 elements:
        if (rightIndex - leftIndex <= 0)
        {
            return;
        }

        // Partition the range of elements and grab the index of the pivot:
        int pivotIndex = Partition(leftIndex, rightIndex);

        // Recursively call this QuickSort method on whatever
        // is to the left of the pivot:
        QuickSort(leftIndex, pivotIndex - 1);

        // Recursively call this QuickSort method on whatever
        // is to the right of the pivot:
        QuickSort(pivotIndex + 1, rightIndex);
    }
    
    [Test]
    public void RunPartition()
    {
        int[] arrayToSort = {10, 2, 8, 6, 7, 3};
        int pivotIndex = Partition(0, arrayToSort.Length - 1);
        int g = 4;
    }
    public int Partition(int leftPointer, int rightPointer)
    {
        int pivotIndex = rightPointer;

        int pivot = Array[pivotIndex];

        rightPointer -= 1;

        while (true)
        {
            while (Array[leftPointer] < pivot)
                leftPointer++;

            while (Array[rightPointer] > pivot)
                rightPointer--;

            if (leftPointer >= rightPointer)
                break;
            else
            {
                (Array[leftPointer], Array[rightPointer]) = (Array[rightPointer], Array[leftPointer]);

                leftPointer++;
            }
        }
        (Array[leftPointer], Array[pivotIndex]) = (Array[pivotIndex], Array[leftPointer]);

        return leftPointer;
    }
    }
}