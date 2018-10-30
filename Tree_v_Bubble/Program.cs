using System;
using System.IO;

namespace Tree_v_Bubble
{
    static class Program
    {
        static void Main(string[] args)
        {

            FileStream output = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter (output);

            TextWriter oldOut = Console.Out;
            
            Tree theTree = new Tree();
            
            List theList = new List();
            
            Console.WriteLine("Welcome to the name sorter!\nPlease enter the file from which you would like to use the names from. -> ");

            string file = Console.ReadLine();
            
            Console.WriteLine();
            
            Console.SetOut(writer);

            foreach (string val in File.ReadAllLines(file))
            {
                int value = Int32.Parse(val);
                theTree.add(value);
                theList.sortAdd(value);
            }
            
            theTree.printTree();
            
            Console.WriteLine("\n\nThe tree took " + theTree.comps + " comparisons.\n");
            
            theList.printList();
            
            Console.WriteLine("\nThe list took " + theList.comps + " comparisons.");
            
            writer.Close();
            
            output.Close();
            
            
            Console.SetOut(oldOut);
            
            theTree.printTree();
            
            Console.WriteLine("\n\nThe tree took " + theTree.comps + " comparisons.");
            
            theList.printList();
            
            Console.WriteLine("\nThe list took " + theList.comps + " comparisons.");
        }
    }
}