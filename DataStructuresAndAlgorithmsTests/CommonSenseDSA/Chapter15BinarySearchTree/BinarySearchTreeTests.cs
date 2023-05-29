namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter15BinarySearchTree
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            this.Value = val;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public TreeNode Search(int searchValue, TreeNode node)
        {
            if (node == null || node.Value == searchValue)
            {
                return node;
            }
            else if (searchValue < node.Value)
            {
                return Search(searchValue, node.LeftChild);
            }
            else
            {
                return Search(searchValue, node.RightChild);
            }
        }

        public void Insert(int value, TreeNode node)
        {
            if (value < node.Value)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new TreeNode(value);
                }
                else
                {
                    Insert(value, node.LeftChild);
                }
            }
            else if (value > node.Value)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new TreeNode(value);
                }
                else
                {
                    Insert(value, node.RightChild);
                }
            }
        }

        public TreeNode Delete(int valueToDelete, TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            else if (valueToDelete < node.Value)
            {
                node.LeftChild = Delete(valueToDelete, node.LeftChild);
                return node;
            }
            else if (valueToDelete > node.Value)
            {
                node.RightChild = Delete(valueToDelete, node.RightChild);
                return node;
            }

            else if (valueToDelete == node.Value)
            {
                if (node.LeftChild == null)
                {
                    return node.RightChild;
                }
                else if (node.RightChild == null)
                {
                    return node.LeftChild;
                }

                else
                {
                    node.RightChild = Lift(node.RightChild, node);
                    return node;
                }
            }
            else
            {
                return null;
            }
        }

        public TreeNode Lift(TreeNode node, TreeNode nodeToDelete)
        {
            if (node.LeftChild != null)
            {
                node.LeftChild = Lift(node.LeftChild, nodeToDelete);
                return node;
            }
            else
            {
                nodeToDelete.Value = node.Value;
                return node.RightChild;
            }
        }
        
        public void TraverseAndPrint(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            TraverseAndPrint(node.LeftChild);
            Console.WriteLine(node.Value);
            TraverseAndPrint(node.RightChild);
        }
        
        /*Write an algorithm that finds the greatest value within a binary search tree.*/
        public void FindGreatest(TreeNode node)
        {
            if(node.RightChild == null)
                Console.WriteLine(node.Value);
            FindGreatest(node.RightChild);
        }

    }

    public class BinarySearchTreeTests
    {

    }
}