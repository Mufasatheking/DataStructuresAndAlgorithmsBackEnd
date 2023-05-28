namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA
{
    public class CH10CH11RecursionTests
    {
        [Test]
        public void RecurseArray()
        {
                var array = new List<object>
                {
                    1,
                    2,
                    3,
                    new List<object> { 4, 5, 6 },
                    7,
                    new List<object>
                    {
                        8,
                        new List<object>
                        {
                            9, 10, 11,
                            new List<object> { 12, 13, 14 }
                        }
                    },
                    new List<object>
                    {
                        15, 16, 17, 18, 19,
                        new List<object>
                        {
                            20, 21, 22,
                            new List<object>
                            {
                                23, 24, 25,
                                new List<object> { 26, 27, 29 },
                                30, 31
                            },
                            32
                        },
                        33
                    }
                };
                PrintArray(array);
        }

        public void PrintArray(List<object> list)
        {
            foreach (var item in list)
            {
                if (item is int)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    PrintArray(item as List<object>);
                }
            }
        }
        
        [Test]
        public void FindAnagram()
        {
            foreach (var anagram in AnagramsOf("abcde"))
            {
                Console.WriteLine(anagram);
            }
        }

        static List<string> AnagramsOf(string str)
        {
            if (str.Length == 1)
            {
                return new List<string> { str };
            }

            List<string> collection = new List<string>();
            var sub = str.Substring(1);
            List<string> substringAnagrams = AnagramsOf(sub);

            foreach (var substringAnagram in substringAnagrams)
            {
                for (int i = 0; i <= substringAnagram.Length; i++)
                {
                    string copy = new string(substringAnagram);
                    var str0 = str[0];
                    collection.Add(copy.Insert(i, str0.ToString()));
                }
            }

            return collection;
        }
    }
}