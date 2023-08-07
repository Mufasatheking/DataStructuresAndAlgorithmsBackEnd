namespace DataStructuresAndAlgorithmsTests.LeetCode.BinarySearch
{
    public class BinarySearchTests
    {
        [Test]
        //[TestCase(0, 4, new int[] { 4, 5, 6, 7, 0, 1, 2 })]
        //[TestCase(3,-1,new int[] {4,5,6,7,0,1,2})]
        //[TestCase(8,4,new int[] {4,5,6,7,8,1,2,3})]
        //[TestCase(3,2,new int[] {5,1,3})]
        //[TestCase(1,0,new int[] {1,3})]
        [TestCase(3,0,new int[] {3,1})]
        public void RotatedBinarySearchTest(int target, int index, int[] nums)
        {
            var pivotIndex = FindPivotIndex(nums);
            int low = -1;
            int high = -1;
            if (target >= nums[0])
            {
                low = 0;
                high = pivotIndex == 0 ? nums.Length : pivotIndex - 1;
            }
            else
            {
                low = pivotIndex;
                high = nums.Length - 1;
            }

            var res = RotatedBinarySearch(target: target, nums: nums, low, high);
            int gg = 4;
        }

        public int FindPivotIndex(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (nums[mid] > nums[high])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }

        public int RotatedBinarySearch(int target, int[] nums, int low, int high)
        {
            int mid = (low + high) / 2;

            while (low <= high)
            {

                int arrMid = nums[mid];

                if (arrMid == target)
                {
                    return mid;
                }
                else if (arrMid > target)
                {
                    high = mid - 1;
                }
                else if (arrMid < target)
                {
                    low = mid + 1;
                }

                mid = (high + low) / 2;
            }

            return -1;
        }
        // [Test]
        // [TestCase(8,2,new int[] {3, 5, 8, 10, 17, 19, 20, 28, 30, 32, 33, 36, 37, 39, 41, 43, 44, 47, 49, 50})]
        // [TestCase(19,7,new int[] {5, 6, 8, 9, 12, 15, 16, 19, 28, 29, 30, 34, 35, 37, 39, 40, 41, 45, 48, 50})]
        // [TestCase(27,10,new int[] {1, 3, 4, 5, 7, 12, 15, 19, 21, 24, 27, 28, 29, 31, 36, 37, 43, 47, 48, 50})]
        // [TestCase(49,18,new int[] {1, 2, 3, 4, 6, 15, 17, 21, 23, 26, 31, 32, 33, 36, 38, 39, 41, 44, 49, 50 })]
        // [TestCase(19,-1,new int[] {1, 2, 3, 4, 6, 15, 17, 21, 23, 26, 31, 32, 33, 36, 38, 39, 41, 44, 49, 50 })]
        // [TestCase(1,-1,new int[] {0, 2 })]
        // public void BinarySearchTest(int target,int index, int[] nums)
        // {
        //     var result = BinarySearch(target: target, nums: nums);
        //     Console.WriteLine($"result:{result} - index:{index}");
        //     Assert.That(result.Equals(index));
        // }
        // public int BinarySearch(int target, int[] nums)
        // {
        //     int low = 0;
        //     int high = nums.Length - 1;
        //     int mid = (nums.Length - 1) / 2;
        //     
        //     while (low<=high)
        //     {
        //         
        //         int arrMid = nums[mid];
        //         
        //         if (arrMid == target)
        //         {
        //             return mid;
        //         }
        //         else if (arrMid > target)
        //         {
        //             high = mid -1;
        //         }
        //         else if (arrMid < target)
        //         {
        //             low = mid + 1;
        //         }
        //         mid = (high+low) / 2;
        //     }
        //
        //     return -1;
        // }
    }
}