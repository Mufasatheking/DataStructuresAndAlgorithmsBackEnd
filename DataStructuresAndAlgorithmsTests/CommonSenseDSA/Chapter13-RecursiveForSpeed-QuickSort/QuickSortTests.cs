namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter13_RecursiveForSpeed_QuickSort
{
    public class QuickSortTests
    {
         public int[] Array { get; }

    public QuickSortTests(int[] array)
    {
        Array = array;
    }

    public void RunPartition()
    {
        int[] arrayToSort = {10, 2, 8, 6, 7, 3};
        int pivotIndex = Partition(0, arrayToSort.Length - 1);
    }
    public int Partition(int leftPointer, int rightPointer)
    {
        // We always choose the right-most element as the pivot.
        // We keep the index of the pivot for later use:
        int pivotIndex = rightPointer;

        // We grab the pivot value itself:
        int pivot = Array[pivotIndex];

        // We start the right pointer immediately to the left of the pivot
        rightPointer -= 1;

        while (true)
        {
            // Move the left pointer to the right as long as it
            // points to value that is less than the pivot:
            while (Array[leftPointer] < pivot)
                leftPointer++;

            // Move the right pointer to the left as long as it
            // points to a value that is greater than the pivot:
            while (Array[rightPointer] > pivot)
                rightPointer--;

            // We've now reached the point where we've stopped
            // moving both the left and right pointers.

            // We check whether the left pointer has reached
            // or gone beyond the right pointer. If it has,
            // we break out of the loop so we can swap the pivot later
            // on in our code:
            if (leftPointer >= rightPointer)
                break;
            else
            {
                // If the left pointer is still to the left of the right
                // pointer, we swap the values of the left and right pointers:
                int temp = Array[leftPointer];
                Array[leftPointer] = Array[rightPointer];
                Array[rightPointer] = temp;

                // We move the left pointer over to the right, gearing up
                // for the next round of left and right pointer movements:
                leftPointer++;
            }
        }
        // As the final step of the partition, we swap the value
        // of the left pointer with the pivot:
        int tempPivot = Array[leftPointer];
        Array[leftPointer] = Array[pivotIndex];
        Array[pivotIndex] = tempPivot;

        // We return the left_pointer for the sake of the quicksort method
        // which will appear later in this chapter:
        return leftPointer;
    }
    }
}