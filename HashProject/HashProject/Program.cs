using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

namespace HashProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the name sorter!\nPlease enter the file from which you would like to use the names from. -> ");

            string file = Console.ReadLine();
            
            //string file = "input.txt";
            
            Console.WriteLine();
            
            ArrayList temp = new ArrayList();

            foreach (string val in File.ReadAllLines(file))
            {
                temp.Add(val);
            }

            /*for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = "#";
            }*/

            makeHash(temp, 200);
            Console.WriteLine();
            makeHash(temp, 400);
            Console.WriteLine();
            makeHash(temp, 700);

        }

        static void makeHash(ArrayList names, int length)
        {
            HashTable hash = new HashTable(length);

            foreach (string name in names)
            {
                hash.addHash(name);
            }
            
            hash.printHash();
            
            Console.WriteLine("There were " + hash.getCollisions() + " collisions.");
        }

        static void print(string printThis)
        {
            Console.Write(printThis);
        }
        
        static void printLn(string printThis)
        {
            Console.WriteLine(printThis);
        }
    }
}