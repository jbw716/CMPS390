using System;
using System.Threading;

namespace Tree_v_Bubble
{
    public class Tree
    {
        private TreeNode root;
        
        private int nodes = 0;

        public Tree(int rootData)
        {
            root = new TreeNode(rootData);

            nodes++;
        }

        public void add(int data)
        {
            TreeNode curr = root;
            bool searching = true;
            
            while (searching)
            {

                if (data < curr.value)
                {
                    if (curr.left == null)
                    {
                        curr.left = new TreeNode(data);
                        nodes++;
                        searching = false;
                    }
                    else
                    {
                        curr = curr.left;
                    }
                }
                else if (data > curr.value)
                {
                    if (curr.right == null)
                    {
                        curr.right = new TreeNode(data);
                        nodes++;
                        searching = false;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }
                else
                {
                    curr.count++;
                }
            }
        }

        public TreeNode printTree(TreeNode node)
        {
            if(node.left != null)
            {
                return printTree(node.left);
            }
            if(node.right != null)
            {
                return printTree(node.right);
            }
            return node;
        }

    }

    public class TreeNode
    {
        public int value;

        public int count;

        public TreeNode left;

        public TreeNode right;

        public TreeNode(int data)
        {
            value = data;
        }
    }
}