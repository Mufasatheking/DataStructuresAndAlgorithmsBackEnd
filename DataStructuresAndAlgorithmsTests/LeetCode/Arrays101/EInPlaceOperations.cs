using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.LeetCode.Arrays101
{
    public class EInPlaceOperations
    {
        [TestCase(new int[] {17,18,5,4,6,1}, new int[] {18,6,6,6,1,-1})]
        [TestCase(new int[] {200}, new int[] {-1})]
        public void ReplaceElementsTests(int[] arr, int[] expectedResult) {
            var result = ReplaceElements(arr);
            Assert.AreEqual(expectedResult,result);
        }
        
        public int[] ReplaceElements(int[] arr)
        {
            (int max, int j) data = GetMaxWithIndex(arr, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    arr[i] = -1;
                    continue;
                }

                if (i == data.j)
                {
                    data = GetMaxWithIndex(arr, i);
                    arr[i] = data.max;
                }
                else
                {
                    arr[i] = data.max;
                }
            }

            return arr;
        }

        public (int max, int j) GetMaxWithIndex(int[] arr, int i)
        {
            (int max, int j) data = (0, 0);
            for (int j = arr.Length - 1; j > i; j--)
            {
                if (arr[j] >= data.max)
                {
                    data.max = arr[j];
                    data.j = j;
                }
            }

            return data;
        }
        
        
        public int[] ReplaceElementsBETTERSOLUTION(int[] arr) {
            int max = -1; 
            for (int i = arr.Length - 1; i >= 0; i--) {
                int current = arr[i];
                arr[i] = max;
                if (current > max)
                    max = current;
            }
            return arr;
        }
        
        [TestCase(new int[] {0,1,0,3,12}, new int[] {1,3,12,0,0})]
        [TestCase(new int[] {4,1,0,0,0,12,3,0,5}, new int[] {4,1,12,3,5,0,0,0,0})]
        public void MoveZeroesTests(int[] arr, int[] expectedResult) {
            var result = MoveZeroes(arr);
            Assert.AreEqual(expectedResult,result);
        }
        public int[] MoveZeroes(int[] nums) {
            int i = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            for (; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
            return nums;
        }
        
        [TestCase(new int[] {3,1,2,4}, new int[] {4,2,1,3})]
        public void SortArrayByParityTests(int[] arr, int[] expectedResult) {
            var result = SortArrayByParity(arr);
            Assert.AreEqual(expectedResult,result);
        }
        public int[] SortArrayByParity(int[] nums) {
            int i = 0;
            int j = nums.Length - 1;

            while(i < j) {
                if(nums[i] % 2 > nums[j] % 2) {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }

                if(nums[i] % 2 == 0) i++;
                if(nums[j] % 2 == 1) j--;
            }

            return nums;

        }
    }
}