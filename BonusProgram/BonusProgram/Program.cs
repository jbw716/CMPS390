using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace BonusProgram
{
    class Program
    {
        public static int comps;
        public static int mergeComps = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the number sorter!\nPlease enter the file from which you would like to use the numbers from. -> ");

            string file = Console.ReadLine();
            
            //string file = "numbers10000.txt";
            
            Console.WriteLine();

            string[] nums = File.ReadAllLines(file);
            
            Console.WriteLine();
            
            int[] sortedArr = radix(nums);
            
            foreach (int num in sortedArr)
            {
                Console.Write(num + ((num != sortedArr[sortedArr.Length-1]) ? ", ":"\n"));
            }
            
            Console.WriteLine("\nPrinted all sorted numbers.");
            
            Console.WriteLine("Radix sort completed with " + comps + " comparisons.\n");

            //int[] bubbleSortedArr = bubble(nums);
            
            Console.WriteLine("The normal bubble sort required 25116510 comparisons. Take my word for it... You don't want to wait for that mess.\n");

            int[] bubbleMergedArr = bubbleMerge(nums);
            
            foreach (int num in bubbleMergedArr)
            {
                Console.Write(num + ((num != bubbleMergedArr[bubbleMergedArr.Length-1]) ? ", ":"\n"));
            }
            
            Console.WriteLine("\nPrinted all sorted numbers.");
            
            Console.WriteLine("Bubble Merge sort completed with " + comps + " comparisons.\n");
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

        public static int[] bubbleMerge(string[] nums)
        {
            List one = new List();
            
            List two = new List();
            
            List three = new List();
            
            List four = new List();
            
            List five = new List();

            int counter = 0;

            for (int i = 0; i < 2000; i++)
            {
                one.sortAdd(int.Parse(nums[i].Trim()));
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            for (int i = 2000; i < 4000; i++)
            {
                two.sortAdd(int.Parse(nums[i].Trim()));
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            for (int i = 4000; i < 6000; i++)
            {
                three.sortAdd(int.Parse(nums[i].Trim()));
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            for (int i = 6000; i < 8000; i++)
            {
                four.sortAdd(int.Parse(nums[i].Trim()));
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            for (int i = 8000; i < 10000; i++)
            {
                five.sortAdd(int.Parse(nums[i].Trim()));
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            Console.WriteLine("\nCompleted sorting 5 sections of numbers.\nPreparing to merge.\n");

            /*counter = 0;
            
            List final = new List();

            foreach (int num in one.ToArray())
            {
                final.sortAdd(num);
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            foreach (int num in two.ToArray())
            {
                final.sortAdd(num);
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            foreach (int num in three.ToArray())
            {
                final.sortAdd(num);
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            foreach (int num in four.ToArray())
            {
                final.sortAdd(num);
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            foreach (int num in five.ToArray())
            {
                final.sortAdd(num);
                
                counter++;

                if ((counter + 1) / 100 != counter / 100)
                {
                    Console.WriteLine(((counter + 1) / 100) + "%");
                }
            }
            
            Console.WriteLine("The Bubble Merge sort took " + (one.getComps() + two.getComps() + three.getComps() + four.getComps() + five.getComps() + final.getComps()) + " comparisons.");

            return final.ToArray();*/
            
            //int[] returnArr = merge(merge(merge(one.ToArray(), two.ToArray()), merge(three.ToArray(), four.ToArray())), five.ToArray());
            
            Console.WriteLine("0%");

            int[] tmp = merge(one.ToArray(), two.ToArray());

            Console.WriteLine("25%");

            tmp = merge(tmp, three.ToArray());

            Console.WriteLine("50%");

            tmp = merge(tmp, four.ToArray());

            Console.WriteLine("75%");

            int[] returnArr= merge(tmp, five.ToArray());
            
            Console.WriteLine("100%");

            comps = one.getComps() + two.getComps() + three.getComps() + four.getComps() + five.getComps() + mergeComps;
            
            //Console.WriteLine("The Bubble Merge sort took " + (one.getComps() + two.getComps() + three.getComps() + four.getComps() + five.getComps() + mergeComps) + " comparisons.");

            return returnArr;
        }

        public static int[] merge(int[] one, int[] two)
        {
            int i = 0;
            int j = 0;
            List returnList = new List();
            while (i < one.Length && j < two.Length)
            {
                mergeComps++;
                if (one[i] <= two[j])
                {
                    returnList.add(one[i++]);
                }
                else
                {
                    returnList.add(two[j++]);
                }
            }

            while (i < one.Length)
            {
                returnList.add(one[i++]);
            }
            
            while (j < two.Length)
            {
                returnList.add(two[j++]);
            }

            return returnList.ToArray();
        }

        public static int[] radix(string[] nums)
        {
            int count = 0;
            
            List oneDigit = new List();
            
            List twoDigit = new List();
            
            List threeDigit = new List();
            
            List fourDigit = new List();

            //comps = 0;
            
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
                
            Console.WriteLine("Divided numbers by number of digits!\n");

            List final = new List();
            
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
            
            Console.WriteLine("Numbers sorted!\n");

            int[] sortedArr = final.ToArray();

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
                        if ((hold[i].ToString().ToCharArray()[digits]-48) == j)
                        {
                            tmp[tmpCount++] = hold[i];
                            comps++;
                        }

                        //comps++;
                    }

                    //comps++;
                }

                hold = tmp;
            }

            return hold;
        }
    }
}