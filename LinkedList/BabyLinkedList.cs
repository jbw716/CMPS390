using System;

namespace q
{
    public class BabyLinkedList
    {

        public static void Mainn(string[] args)
        {
            //List myList = new List();
            
            /*myList.add(1);
            
            myList.add(2);
            
            Console.WriteLine(myList.getAt(0) + "..." + myList.getAt(1));*/
            
            List myList = new List();
            
            Console.Write("How many nodes would you like? -> ");

            int numNodes = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numNodes; i++)
            {
                myList.add(i);
            }

            bool end = false;

            while (!end)
            {
            
                Console.Write("\nHere's what your list currently looks like. -> ");
                myList.printList();

                Console.Write(
                    "\n\nWould you like to:\n1. Add another node somewhere\n2. Delete a node\n3. Get the value of a node\n4. End the program?\n-> ");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1: Console.Write("\nDope! Enter the index at which you would like to insert the new node after. (For the illiterate... index starts at 0; not 1) -> ");
                        int setterIndex = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nPlease enter the value that you would like to set the node to. -> ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        myList.insertAfter(setterIndex, num);
                        Console.Write("\nSick! Here's your new list! -> ");
                        myList.printList();
                        break;
                    
                    case 2: Console.Write("\nI gotchu fam... What's the index of the node you'd like to obliterate? -> ");
                        int obliterateIndex = Convert.ToInt32(Console.ReadLine());
                        myList.delAt(obliterateIndex);
                        Console.Write("ZOIKS! I can't believe you just obliterated that node! And after I worked so hard to put it there for you!");
                        break;
                    
                    case 3: Console.Write("\nOn it... What's the index of the node that you'd like the value for? (For the illiterate... index starts at 0; not 1) -> ");
                        int getterIndex = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Here ya go my guy. -> " + myList.getAt(getterIndex));
                        break;
                    
                    case 4: Console.Write("\nOh... Okay... That's cool I guess. Bye then.");
                        end = true;
                        break;
                    
                    default: Console.Write("\nI'm too lazy to try and figure out what that means, so I'mma just go away now.");
                        end = true;
                        break;
                }

                Console.WriteLine();
            }
        }

    }
}