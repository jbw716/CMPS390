using System;
using System.Threading;

namespace Tree_v_Bubble
{
    public class Tree
    {
        public TreeNode root = null;
        
        private int nodes = 0;

        public int comps = 0;

        /*public Tree(int rootData)
        {
            root = new TreeNode(rootData);

            nodes++;
        }*/

        public void add(int data)
        {

            if (root == null)
            {
                root = new TreeNode(data);
                
                nodes++;
            }
            
            else
            {
                TreeNode curr = root;
                bool searching = true;

                while (searching)
                {

                    if (data < curr.value)
                    {
                        comps++;
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
                        comps += 2;
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
                        comps += 2;
                        curr.count++;
                        searching = false;
                    }
                }
            }
        }

        public void printTree()
        {
            if (root.left != null) {
                printTree(root.left);
            }

            for (int i = 0; i < root.count; i++)
            {
                Console.Write(root.value + " ");
            }

            if (root.right != null) {
                printTree(root.right);
            }
        }

        public void printTree(TreeNode node)
        {
            if (node.left != null) {
                printTree(node.left);
            }

            for (int i = 0; i < node.count; i++)
            {
                Console.Write(node.value + " ");
            }

            if (node.right != null) {
                printTree(node.right);
            }
        }

    }

    public class TreeNode
    {
        public int value, count;

        public TreeNode left, right;

        public TreeNode(int data)
        {
            value = data;

            count = 1;
        }
    }
}