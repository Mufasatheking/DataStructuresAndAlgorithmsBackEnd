using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructuresAndAlgorithmsTests.LeetCode.Arrays101
{
    public class DSearchingTests
    {
        #region CheckIfExist
        [Test]
        [TestCase(new int[] { 4, -7, 11, 4, 18 }, false)]
        [TestCase(new int[] { 0,0}, true)]
        public async Task CheckIfExistTests(int[] arr, bool expectedResult)
        {
            var result = await CheckIfExist(arr);
            Assert.AreEqual(expectedResult,result);
        }
        
        public async Task<bool> CheckIfExist(int[] arr)
        {
            var hashtable = new Hashtable();
            for (int i = 0; i < arr.Length; i++)
            {
                if (hashtable.ContainsKey(arr[i] * 2) || (arr[i] % 2 == 0 && hashtable.ContainsKey(arr[i] / 2)))
                    return true;
                
                if(!hashtable.ContainsKey(arr[i]))
                    hashtable.Add(arr[i], i);
            }
            return false;
        }
        #endregion
        
        [TestCase(new int[] { 2,1 }, false)]
        [TestCase(new int[] { 3,5,5 }, false)]
        [TestCase(new int[] { 0,3,2,1 }, true)]
        [TestCase(new int[] { 0,1,2,3,4,5,6,7,8,9 }, false)]
        [TestCase(new int[] { 9,8,7,6,5,4,3,2,1,0 }, false)]
        public void ValidMountainArrayTests(int[] arr, bool expectedResult) {
            var result = ValidMountainArray(arr);
            Assert.AreEqual(expectedResult,result);
        }
        
        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
                return false;
            var ascending = true;
            var descending = false;

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (ascending)
                {
                    if(arr[i +1] > arr[i])
                        continue;
                    if (arr[i + 1] == arr[i])
                        return false;
                    if (arr[i + 1] < arr[i])
                    {
                        if (i == 0)
                            return false;
                        ascending = false;
                        descending = true;
                    }
                }

                if (descending)
                {
                    if (arr[i + 1] >= arr[i])
                        return false;
                }
            }
            return descending;
        }
    }
}
