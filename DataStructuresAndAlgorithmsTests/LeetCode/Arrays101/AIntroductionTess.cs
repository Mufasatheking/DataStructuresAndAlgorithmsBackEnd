using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.LeetCode.Arrays101;

public class AIntroductionTess
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public async Task SortedSquares()
    {
        var nums = new int[]
        {
            -4,-1,0,3,10
        };
        var result = await SortedSquares(nums);
        Assert.Pass();
    }

    public async Task<int[]> SortedSquares(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int[] result = new int[nums.Length];
        for (int p = nums.Length - 1; p >= 0; p--) {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right])) {
                result[p] = nums[left] * nums[left];
                left++;
            } else {
                result[p] = nums[right] * nums[right];
                right--;
            }
        }

        return result;
    }
    [Test]
    public async Task FindNumbersWithEvenNumberOfDigitsTest()
    {
        var nums = new int[]
        {
            12,345,2,6,7896
        };
        var result = await FindNumbersWithEvenNumberOfDigits(nums);
        Assert.Pass();
    }

    public async Task<int> FindNumbersWithEvenNumberOfDigits(int[] nums)
    {
        var count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var digits = 0;
            while (current >= 1)
            {
                current= current / 10;
                digits++;
            }

            if (digits % 2 == 0) count++;
        }

        return count;
    }
    
    [Test]
    public async Task FindMaxConsecutiveOnesTest()
    {
        var array = new int[]
        {
            1, 1, 0, 1, 1, 1
        };
        var result = await FindMaxConsecutiveOnes(array);
        Assert.Pass();
    }
    public async Task<int> FindMaxConsecutiveOnes(int[] nums) {
        int currentMax = 0;
        var newMax = 0;
        var currentlyConsecutive = false;
        for(int i = 0; i < nums.Length;i++){
           
            if(nums[i] == 1){
                currentlyConsecutive = true;
            }else{
                currentlyConsecutive = false;
            }
            if(currentlyConsecutive){
                newMax++;
                if((i == nums.Length - 1) && (newMax > currentMax))  currentMax = newMax;
            }else{
                if(newMax > currentMax){
                    currentMax = newMax;
                } 
                newMax = 0;
            }
        }

        return currentMax;
    }
}