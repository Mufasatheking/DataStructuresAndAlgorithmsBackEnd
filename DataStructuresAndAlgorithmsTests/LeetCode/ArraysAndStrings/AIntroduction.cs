namespace DataStructuresAndAlgorithmsTests.LeetCode.ArraysAndStrings
{
    public class AIntroduction
    {
        [Test]
        public void PivotIndexTest()
        {
            var array = new int[] { -1, -1, 1, 1, -1, -1 };
            var result = PivotIndex(array);
            Assert.IsTrue(true);
        }
        public int PivotIndex(int[] nums) {
            int leftCount = 0;
            int rightCount = 0;
            for(int i = 1; i<nums.Length; i++){
                rightCount += nums[i];
            }
        
            if(rightCount == 0){
                return 0;
            }
        
            for(int i = 1; i<nums.Length; i++){
                leftCount += nums[i-1];
                rightCount = rightCount - nums[i];
                if(leftCount == rightCount){
                    return i;
                }
            }

            if (leftCount == 0)
                return nums.Length - 1;
            return -1;
        }
    }
}