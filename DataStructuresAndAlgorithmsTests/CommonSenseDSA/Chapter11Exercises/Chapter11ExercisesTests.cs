namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter11Exercises
{
    public class Chapter11ExercisesTests
    {
        /*1.Use recursion to write a function that accepts an array of strings and returns the total number of characters
         across all the strings. For example, if the input array is ["ab", "c", "def", "ghij"],
         the output should be 10 since there are 10 characters in total.*/
        [Test]
        public void StringCharacterCountTest()
        {
            var array = new string[] { "ab", "c", "def", "ghij" };
            var count = CharacterCount(array);
            Assert.That(count == 10);
        }

        public int CharacterCount(string[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
                return arr[index].Length;
    
            return arr[index].Length + CharacterCount(arr, index + 1);
        }
        
        /*2.Use recursion to write a function that accepts an array of numbers and returns a new array
         containing just the even numbers.*/
        [Test]
        public void EvensOnlyTest()
        {
            //var array = new List<int> { 1,2,3,4,5,6,7,8 };
            var array = new List<int> { 11,1,3,3,7,2,3,4,5,6,7,8 };
            var newList = EvensOnly(array);
            int g = 5;
            // Assert.That(10 == 10);
        }

        public List<int> EvensOnly(List<int> arr, int index = 0)
        {
            if (index == arr.Count)
                return new List<int>();
    
            List<int> result = EvensOnly(arr, index + 1);
    
            if (arr[index] % 2 == 0)
                result.Insert(0, arr[index]);

            return result;
        }
        
        /*3.There is a numerical sequence known as “Triangular Numbers.”
         The pattern begins as 1, 3, 6, 10, 15, 21, and continues onward with the Nth number in the pattern, 
         which is N plus the previous number. For example, the 7th number in the sequence is 28, 
         since it’s 7 (which is N) plus 21 (the previous number in the sequence).
        Write a function that accepts a number for N and returns the correct number from the series. 
        That is, if the function was passed the number 7, the function would return 28.*/
        //28,21,15,10,6,3,1
        [Test]
        public void TriangleNumbersTest()
        {
            var N = 7;
            var result = TriangleNumbers(7);
            Assert.That(result == 28);
        }

        public int TriangleNumbers(int N)
        {
            if (N == 1)
                return 1;

            return N + TriangleNumbers(N - 1);
        }

        /*4.Use recursion to write a function that accepts a string and returns the first index that
         contains the character “x.” For example, the string, "abcdefghijklmnopqrstuvwxyz" has an “x” at index 23. 
         To keep things simple, assume the string definitely has at least one “x.”*/
        [Test]
        public void FirstXTest()
        {
            var testString = "abcdefghijklmnopqrstuvwxyz";
            var result = FirstX(testString, 0);
            Assert.That(result == 23);
        }

        public int FirstX(string testString, int index)
        {
            if (testString[index] == 'x')
                return index;
    
            return FirstX(testString, index + 1);
        }
        
        /*5.This problem is known as the “Unique Paths” problem: Let’s say you have a grid of rows and columns.
         Write a function that accepts a number of rows and a number of columns, and calculates the number of possible
        “shortest” paths from the upper-leftmost square to the lower-rightmost square.
        For example, here’s what the grid looks like with three rows and seven columns. 
        You want to get from the “S” (Start) to the “F” (Finish).

        By “shortest” path, I mean that at every step, you’re moving either one step to the right:or one step downward:
        Again, your function should calculate the number of shortest paths.*/
        
        [Test]
        public void ShortestPathsTest()
        {
            var testString = "abcdefghijklmnopqrstuvwxyz";
            var result = ShortestPaths(3, 5);
            Assert.That(result == 15);
        }

        public int ShortestPaths(int rows, int columns)
        {
            if (rows == 1 || columns == 1)
                return 1;
            return ShortestPaths(rows - 1, columns) + ShortestPaths(rows, columns - 1);
        }
        
        
    }
}