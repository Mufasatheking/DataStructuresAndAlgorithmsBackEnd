namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter17Tries
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }
    public class Trie
    {
        public TrieNode Root { get; set; }

        public Trie()
        {
            Root = new TrieNode();
        }
        /*Write a function that traverses each node of a trie and prints each key, including all "*" keys.*/
        public void PrintAll()
        {
            TrieNode currentNode = Root;
        }

        public void PrintAllRecursive(TrieNode node)
        {
            if(node.Children.Count == 0)
                return;
            
            foreach (var child in node.Children)
            {
                Console.WriteLine(child.Key);
                PrintAllRecursive(child.Value);
            }
        }
        public TrieNode Search(string word)
        {
            TrieNode currentNode = Root;

            foreach (char charKey in word)
            {
                if (currentNode.Children.ContainsKey(charKey))
                {
                    currentNode = currentNode.Children[charKey];
                }
                else
                {
                    return null;
                }
            }

            return currentNode;
        }
        public void Insert(string word)
        {
            TrieNode currentNode = Root;

            foreach (char charKey in word)
            {
                if (currentNode.Children.ContainsKey(charKey))
                {
                    currentNode = currentNode.Children[charKey];
                }
                else
                {
                    TrieNode newNode = new TrieNode();
                    currentNode.Children[charKey] = newNode;
                    currentNode = newNode;
                }
            }

            // After inserting the entire word into the Trie,
            // we add a * key at the end:
            currentNode.Children['*'] = null;
        }
        
        
        public List<string> CollectAllWords(TrieNode node = null, string word = "", List<string> words = null)
        {
            TrieNode currentNode = node ?? Root;

            if (words == null)
            {
                words = new List<string>();
            }

            foreach (KeyValuePair<char, TrieNode> kvp in currentNode.Children)
            {
                char key = kvp.Key;
                TrieNode childNode = kvp.Value;

                if (key == '*')
                {
                    words.Add(word);
                }
                else
                {
                    CollectAllWords(childNode, word + key, words);
                }
            }

            return words;
        }

        public List<string> Autocomplete(string prefix)
        {
            TrieNode currentNode = Search(prefix);

            if (currentNode == null)
            {
                return null;
            }

            return CollectAllWords(currentNode);
        }
        
        public string Autocorrect(string word)
        {
            TrieNode currentNode = Root;
            string wordFoundSoFar = "";

            foreach (char charInWord in word)
            {
                if (currentNode.Children.ContainsKey(charInWord))
                {
                    wordFoundSoFar += charInWord;
                    currentNode = currentNode.Children[charInWord];
                }
                else
                {
                    return wordFoundSoFar + CollectAllWords(currentNode)[0];
                }
            }

            return word;
        }
    }
    
    public class TrieTests
    {
        
    }
}