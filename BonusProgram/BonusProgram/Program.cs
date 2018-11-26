using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace BonusProgram
{
    class Program
    {
        public static int comps;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the number sorter!\nPlease enter the file from which you would like to use the numbers from. -> ");

            //string file = Console.ReadLine();
            
            string file = "numbers10000.txt";
            
            Console.WriteLine();
            
            /*List temp = new List();

            foreach (string num in File.ReadAllLines(file))
            {
                temp.add(int.Parse(num));
            }*/

            string[] nums = File.ReadAllLines(file);
            
            Console.WriteLine();
            
            int[] sortedArr = radix(nums);
            
            foreach (int num in sortedArr)
            {
                Console.Write(num + ((num != sortedArr[sortedArr.Length-1]) ? ", ":"\n"));
            }
            
            Console.WriteLine("\nPrinted all sorted numbers.");
            
            Console.WriteLine("Sort completed with " + comps + " comparisons.\n");

            //int[] bubbleSortedArr = bubble(nums);
            
            Console.WriteLine("The normal bubble sort required 25116510 comparisons. Take my word for it... You don't want to wait for that mess.");
        }

        public static int[] bubble(string[] nums)
        {
            
            List bubble = new List();

            int counter = 0;
            
            foreach (string num in nums)
            {
                bubble.sortAdd(int.Parse(num.Trim()));

                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                    if ((counter + 1) / 100 == 25)
                    {
                        Console.WriteLine("This is gonna take a hot minute...");
                    }
                }
                
            }
            
            Console.WriteLine("The normal bubble sort required " + bubble.getComps() + " comparisons.");

            return bubble.ToArray();
        }

        public static int[] radix(string[] nums)
        {
            int count = 0;
            
            List oneDigit = new List();
            
            List twoDigit = new List();
            
            List threeDigit = new List();
            
            List fourDigit = new List();
            
            foreach (string num in nums)
            {
                int digits = num.Trim().Length;

                switch (digits)
                {
                    case 1:
                        oneDigit.add(int.Parse(num.Trim()));
                        break;
                    case 2:
                        twoDigit.add(int.Parse(num.Trim()));
                        break;
                    case 3:
                        threeDigit.add(int.Parse(num.Trim()));
                        break;
                    case 4:
                        fourDigit.add(int.Parse(num.Trim()));
                        break;
                    default:
                        Console.WriteLine("Uh oh...");
                        break;
                }

                count++;

                if ((count + 1) / 100 != count / 100)
                {
                    Console.WriteLine(((count + 1) / 100) + "%");
                }

            }
                
            Console.WriteLine("\nDivided numbers by number of digits!\n");

            List final = new List();

            /*foreach (int num in oneDigit.ToArray())
            {
                //Console.WriteLine(num);
            }*/
            
            Console.WriteLine("0%");

            foreach (int num in sortArr(oneDigit.ToArray(), 1))
            {
                //Console.WriteLine(num);
                final.add(num);
            }
            
            Console.WriteLine("25%");
            
            foreach (int num in sortArr(twoDigit.ToArray(), 2))
            {
                //Console.WriteLine(num);
                final.add(num);
            }
            
            Console.WriteLine("50%");
            
            foreach (int num in sortArr(threeDigit.ToArray(), 3))
            {
                //Console.WriteLine(num);
                final.add(num);
            }
            
            Console.WriteLine("75%");
            
            foreach (int num in sortArr(fourDigit.ToArray(), 4))
            {
                //Console.WriteLine(num);
                final.add(num);
            }
            
            Console.WriteLine("100%");
            
            Console.WriteLine("Numbers sorted!");

            /*int[] arrOne = oneDigit.ToArray();

            foreach (int num in arrOne)
            {
                final.add(num);
            }

            int[] arrTwo = twoDigit.ToArray();

            foreach (int num in arrTwo)
            {
                final.add(num);
            }

            int[] arrThree = threeDigit.ToArray();

            foreach (int num in arrThree)
            {
                final.add(num);
            }

            int[] arrFour = fourDigit.ToArray();

            foreach (int num in arrFour)
            {
                final.add(num);
            }*/

            int[] sortedArr = final.ToArray();
            
            //Console.WriteLine("Sort completed with " + (oneDigit.getComps() + twoDigit.getComps() + threeDigit.getComps() + fourDigit.getComps()) + " comparisons.");

            return sortedArr;
        }
        
        public static int[] sortArr(int[] arr, int digits)
        {
            int[] hold = arr;
            digits--;
            for (; digits >= 0; digits--)
            {
                int[] tmp = new int[hold.Length];

                int tmpCount = 0;

                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < hold.Length; i++)
                    {
                        //Console.WriteLine(digits);
                        if ((hold[i].ToString().ToCharArray()[digits]-48) == j)
                        {
                            //tmp.add(hold[i]);

                            tmp[tmpCount++] = hold[i];

                            //Console.WriteLine(arr[i]);

                        }

                        comps++;
                    }
                }

                hold = tmp;
            }

            return hold;
        }
    }
}