using System;

namespace Tree_v_Bubble
{
    static class Program
    {
        static void Main(string[] args)
        {
            Tree theTree = new Tree(1);
            
            theTree.add(9);
            
            theTree.add(2);
            
            theTree.add(10);
            
            theTree.add(11);
            
            theTree.add(8);
            
            theTree.printTree();
        }
    }
}