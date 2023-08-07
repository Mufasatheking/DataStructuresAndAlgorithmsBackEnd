namespace DataStructuresAndAlgorithmsTests.LeetCode.BinarySearch
{
    public class FindPeakElementTests
    {
        [Test]
        //[TestCase(new int[] {1,2,3,1})]
        //[TestCase(new int[] {1,2,1,3,5,6,4})]
        [TestCase(new int[] {1,2})]
        public void FindPeakElementTest(int[] nums)
        {
            int res = FindPeakElement(nums);
            int fff = 4;
        }
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = (left+right) / 2;
            while (left <= right)
            {
                int arrLeft = mid-1 >= 0 ? nums[mid-1] : Int32.MinValue;
                int arrMid = nums[mid];
                int arrRight = mid+1 <= nums.Length-1 ? nums[mid+1] : Int32.MinValue;
                
                if (arrMid>arrRight && arrMid>arrLeft)
                {
                    return mid;
                }
                else if (arrMid < arrRight)
                {
                    left = mid;
                }
                else if (arrMid < arrLeft)
                {
                    right = mid;
                }
                mid = (left+right) / 2;
                if (mid == Int32.MinValue)
                    return -1;
            }

            return -1;
        }

    }
}