namespace DataStructuresAndAlgorithmsTests.LeetCode.BinarySearch
{
    public class BinarySearchFirstAndLastTests
    {
        [Test]
        //[TestCase(new int[]{5,7,7,8,8,10},8)]
        //[TestCase(new int[]{2,2},2)]
        [TestCase(new int[]{1,4},4)]
        //[TestCase(new int[]{1,1,2},1)]
        public void FindTargetTest(int[] nums, int target)
        {
            var targetIndex = SearchRange(nums, target);
            int aa = 4;
        }
        public int[] SearchRange(int[] nums, int target) {
            int targetIndex = FindTarget(nums,target);
            if(targetIndex == -1)
                return new int[] { -1, -1 };
            
            if(nums.Length == 1){
                return new int[]{targetIndex,targetIndex};
            }
            var left = targetIndex == 0 ? 0 : FindLeft(nums, target, 0, targetIndex);
            var right = FindRight(nums, target, targetIndex, nums.Length - 1);
            return new int[]{left,right};
        }
        public int FindLeft(int[] nums, int target, int left, int right){
            while(left< right)
            {
                int mid = left + (right - left) / 2;
                if (mid == 0)
                    return mid;
                if(nums[mid] == target && nums[mid-1] != target)
                    return mid;
                if(nums[mid] == target && nums[mid-1] == target){
                    right = mid - 1;
                }else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
        public int FindRight(int[] nums, int target, int left, int right){
            while(left< right-1)
            {
                int mid = left + (right - left) / 2;
                 if (mid == nums.Length - 1)
                     return mid;
                if(nums[mid] == target && nums[mid+1] != target)
                    return mid;
                if(nums[mid] == target && nums[mid+1] == target){
                    left = mid + 1;
                }else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
        public int FindTarget(int[] nums, int target){
            int left = 0;
            int right = nums.Length -1;

            while(left<= right)
            {
                int mid = left + (right - left) / 2;

                if(nums[mid] == target)
                    return mid;
                if(nums[mid] > target){
                    right = mid - 1;
                }else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}