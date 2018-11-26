using System;
using System.Collections.Generic;

namespace HashProject
{
    public class HashTable
    {
        string[] arr;
        
        int collisions = 0;

        private int length;

        public HashTable(int sentLength)
        {
            length = sentLength;
            
            arr = new string[length];
        }

        int makeNameCode(string name){
            int code = (
                ((name[0]-'a')*(int)Math.Pow(26, 2)) + 
                ((name[1]-'a')*(int)Math.Pow(26, 1)) +
                ((name[2]-'a')*(int)Math.Pow(26, 0))
            );
            return code;
        }

        public void addHash(string name)
        {
            int code = makeNameCode(name);

            switch (length)
            {
                case 200: code = code / 90;
                    break;
                case 400: code = code / 50;
                    break;
                case 700: code = code / 30;
                    break;
                default: code = code / 90;
                    break;
            }
            
            //code = code / 90;
            
            //Console.Write(code);

            while (true)
            {
                if (String.IsNullOrEmpty(arr[code]))
                {
                    break;
                }

                code++;

                collisions++;
            }

            arr[code] = name;
        }

        public void printHash()
        {
            foreach (string name in arr)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    Console.WriteLine(name);
                }
            }
        }

        public int getCollisions()
        {
            return collisions;
        }
    }
}