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
            
            ///////////////////////////////names.sortAlphabetical();

            //names = names.yetAnotherSort();
            
            Console.WriteLine();
            
            //Console.WriteLine(names.getAt(72));

            bool end = false;

            while (!end)
            {

                names.index();

                Console.Write("\nWhat would you like to do?\n1. Display the list.\n2. Get the length of the list.\n3. Delete a name.\n4. Display names starting with a given letter.\n5. End the program.\n>");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        names.printList();
                        break;
                    case "2":
                        Console.WriteLine("\nThere are " + (names.getEnd() + 1) + " names in the list.");
                        break;
                    case "3":
                        Console.Write("\nPlease input which name you would like to delete: ");
                        string name = Console.ReadLine();
                        delName(name, names);
                        break;
                    case "4":
                        Console.Write("\nPlease input a letter: ");
                        names.printWithLetter(Console.ReadLine()[0]);
                        break;
                    case "5": end = true;
                        break;
                    default:
                        Console.WriteLine("That's not a valid input silly");
                        break;
                }
            }

            /*for (int i = 0; i <= names.getEnd(); i++)
            {
                Console.WriteLine(names.getAt(i));
            }*/
        }

        public static void delName(string name, StrList names)
        {
            bool performed = false;
            int endLoop = names.getEnd();
            for (int i = 0; i <= endLoop; i++)
            {
                if (names.getAt(i) == name)
                {
                    names.delAt(i);
                    performed = true;
                    endLoop--;
                }
            }

            if (!performed)
            {
                Console.WriteLine("Name not found in the list.");
            }
            else
            {
                Console.WriteLine(name + " has been deleted from the list.");
            }
        }
    }
}