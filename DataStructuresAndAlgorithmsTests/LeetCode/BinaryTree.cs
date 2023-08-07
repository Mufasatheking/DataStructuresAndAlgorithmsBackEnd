namespace DataStructuresAndAlgorithmsTests.LeetCode
{
    
 // Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
    }
  }
 
    public class Solution {

        [Test]
        public void checkBfsCode()
        {
            var inorder = new int[] { 2, 11, 14, 23, 27, 34, 35, 58, 62, 66, 75, 81, 82, 91, 97 };
            var preorder = new int[] { 58, 23, 11, 2, 14, 34, 27, 35, 81, 66, 62, 75, 91, 82, 97 };
            var root = BuildTreeFromPreAndIn(preorder, inorder);
            //PrintLevels(root);
            Console.WriteLine("----");
            PrintLevel2(root, 4);
            Assert.IsTrue(true);
        }
        
        public void PrintLevel2(TreeNode root, int level)
        {
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));

            while(queue.Count > 0)
            {
                Tuple<TreeNode, int> nodeTuple = queue.Dequeue();
                TreeNode node = nodeTuple.Item1;
                int currentLevel = nodeTuple.Item2;

                if(currentLevel == level)
                {
                    Console.Write(node.val + " ");
                }

                if(node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, currentLevel + 1));
                }

                if(node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, currentLevel + 1));
                }
            }
        }

        private int preorderIndex;
        private Dictionary<int, int> inorderIndexMap;
        public void PrintLevels(TreeNode root)
        {
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            int currentLevel = -1;

            while(queue.Count > 0)
            {
                Tuple<TreeNode, int> nodeTuple = queue.Dequeue();
                TreeNode node = nodeTuple.Item1;
                int level = nodeTuple.Item2;

                if(level != currentLevel)
                {
                    currentLevel = level;
                    Console.WriteLine("\nLevel " + currentLevel + ":");
                }

                Console.Write(node.val + " ");

                if(node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, level + 1));
                }

                if(node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, level + 1));
                }
            }
        }

        public TreeNode BuildTreeFromPreAndIn(int[] preorder, int[] inorder) 
        {
            preorderIndex = 0;
            // build a hashmap to store value -> its index relations
            inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) 
            {
                inorderIndexMap.Add(inorder[i], i);
            }
            return ArrayToTree(preorder, 0, preorder.Length - 1);
        }

        private TreeNode ArrayToTree(int[] preorder, int left, int right) 
        {
            // if there are no elements to construct the tree
            if (left > right) return null;

            // select the preorder_index element as the root and increment it
            int rootValue = preorder[preorderIndex++];
            TreeNode root = new TreeNode(rootValue);

            // build left and right subtree
            // excluding inorderIndexMap[rootValue] element because it's the root
            root.left = ArrayToTree(preorder, left, inorderIndexMap[rootValue] - 1);
            root.right = ArrayToTree(preorder, inorderIndexMap[rootValue] + 1, right);
            return root;
        }
        
        [Test]
        public void BuildTreePreOrderTest()
        {
            //preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
            var preorder = new int[] { 32, 25, 9, 30, 31, 57, 37, 59, 77 };
            var inorder = new int[] { 9, 25, 30, 31, 32, 37, 57, 59, 77 };
            //var preorder = new int[] { 25, 9, 30, 31 };
            //var inorder = new int[] { 9, 25, 30, 31 };

            var rootnode = BuildTree(preorder, inorder);
            Assert.IsTrue(true);

        }

        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            if (preorder == null || preorder.Length == 0)
            {
                return null;
            }
            int rootValue = preorder[0];
            TreeNode rootNode = new TreeNode(rootValue);
            
            int rootIndexInOrder = Array.IndexOf(inorder, rootValue);
            var leftInorder = inorder[0..rootIndexInOrder];
            var leftPreorder = leftInorder.Length == 0 ? new int[0] : preorder[1..(leftInorder.Length + 1)];
            var rightInorder = inorder[(rootIndexInOrder + 1)..];
            var rightPreorder = leftInorder.Length + 1 == preorder.Length ? new int[0] :preorder[(leftInorder.Length + 1)..];

            rootNode.left = BuildTree(leftPreorder, leftInorder);
            rootNode.right = BuildTree(rightPreorder, rightInorder);
            return rootNode;
        }
        
        /*[Test]
        public void BuildTreeTest()
        {
            /*var inOrder = new int[] { 9, 3, 15, 20, 7 };
            var postorder = new int[] { 9, 15, 7, 20, 3 };#1#
            var inOrder = new int[] { 2,1 };
            var postorder = new int[] { 2,1 };
            var result = BuildTree2(inOrder, postorder);
            Assert.IsTrue(true);
        }
        public TreeNode BuildTree2(int[] inorder, int[] postorder) {
            if (postorder == null || postorder.Length == 0)
            {
                return null;
            }
            var rootVal = postorder[postorder.Length-1];
            var rootNode = new TreeNode(rootVal, null, null);
            if(postorder.Length == 1){
                return rootNode;
            }
            var rootIndex = Array.IndexOf(inorder, rootVal);
            List<int> leftTreeIn = null;
            List<int> leftTreePost = null;
            if (rootIndex != 0)
            {
                leftTreeIn = inorder[0..rootIndex].ToList();
                leftTreePost = postorder[0..rootIndex].ToList();
            }

            List<int> rightTreeIn = null;;
            List<int> rightTreePost = null;
            if(rootIndex != inorder.Length){
                rightTreeIn = inorder[(rootIndex+1)..(inorder.Length)].ToList();
                rightTreePost = postorder[rootIndex..(postorder.Length-1)].ToList();
            }   

    
            rootNode.left = leftTreeIn != null ? BuildTree(leftTreeIn.ToArray(), leftTreePost.ToArray()) : null;
            rootNode.right = rightTreeIn != null ? BuildTree(rightTreeIn.ToArray(), rightTreePost.ToArray()) : null;
            return rootNode;
        }*/
    }
}