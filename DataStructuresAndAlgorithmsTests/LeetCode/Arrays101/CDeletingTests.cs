using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.LeetCode.Arrays101
{
    public class CDeletingTests
    {
        [Test]
        public async Task RemoveElementTests()
        {
            //int[] nums = new int[]{0,1,2,2,3,0,4,2};
            int[] nums = new int[]{3,3};
            int valueToRemove = 3;
            int finalCount = 5;
            var output = new int[8];
            output[0] = 0;
            output[1] = 1;
            output[2] = 4;
            output[3] = 0;
            output[4] = 3;
            var result = await RemoveElement(nums,valueToRemove);
            Assert.Pass();
        }
        
        public async Task<int> RemoveElement(int[] nums, int val)
        {
            var valCount = 0;
            var endIndex = 0;
            if (nums.Length == 1)
                return 0;
            
            for (int i = 0; i < nums.Length-endIndex; i++)
            {
                if (nums[i] == val)
                {
                    endIndex++;
                    while (nums[nums.Length - endIndex] == val && (nums.Length - endIndex) != i)
                    {
                        endIndex++;
                    }
                    var swap = nums[nums.Length - endIndex];
                    nums[nums.Length - endIndex] = nums[i];
                    nums[i] = swap;
                }
            }

            int aaa = endIndex;
            var xxx = nums;
            return 5;
        }
        public int RemoveDuplicates(int[] nums) {
        
            if (nums.Length == 0) return 0;
    
            int i = 0; // Pointer for iterating over the array
    
            for (int j = 1; j < nums.Length; j++) 
            {
                // If the current element is not equal to the previous one,
                // copy it to the next position of the last non-duplicate element
                if (nums[j] != nums[i]) 
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
    
            // Return the number of unique elements, which is i+1 (since i is 0-based)
            return i + 1;
        }
    }
}