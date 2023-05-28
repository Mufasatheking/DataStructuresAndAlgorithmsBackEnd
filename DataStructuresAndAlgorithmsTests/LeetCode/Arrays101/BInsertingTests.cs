using System.Globalization;

namespace DataStructuresAndAlgorithmsTests.LeetCode.Arrays101
{
    public class BInsertingTests
    {
        [Test]
        public async Task DuplicateZerosTests()
        {
            var nums = new int[]
            {
                1,0,2,3,0,4,5,0
            };
            var result = await DuplicateZeros(nums);
            Assert.Pass();
        }
        
        public async Task<int[]> DuplicateZeros(int[] arr) {
            int zeroCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == 0)zeroCount++;
            }

            int[] newArray = new int[arr.Length + zeroCount];

            int x = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)
                {
                    newArray[x] = 0;
                    if(x+1 < newArray.Length)newArray[x+1] = 0;
                    x += 2;
                }
                else
                {
                    newArray[x] = arr[j];
                    x++;
                }
            }

            for (int z = 0; z < arr.Length; z++)
            {
                arr[z] = newArray[z];
            }

            return arr;
        }
    }
}