using System;

namespace q
{
    public class BooList
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the name sorter!\nPlease enter the file from which you would like to use the names from. -> ");

            string file = Console.ReadLine();
            
            StrList names = new StrList();

            //string[] nameArr = System.IO.File.ReadAllLines(file);

            foreach (var name in System.IO.File.ReadAllLines(file))
            {
                names.add(name);
            }

            //StrList sorted = names.sortAlpha();
            //names.sortAlpha();
            
            //names.lazySort();

            names = names.yuckSort();

            //names = names.otherSort();
            
            //names.sortAlphabetical();

            //names.yetAnotherSort();
            
            Console.WriteLine();

            for (int i = 0; i <= names.getEnd(); i++)
            {
                Console.WriteLine(names.getAt(i));
            }
        }
    }
}