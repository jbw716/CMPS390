using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace BonusProgram
{
    public class List
    {
        private Node front;
        private bool empty;
        private int end;

        private int comps = 0;

        public List()
        {
            empty = true;
            end = -1;
        }

        public void add(int d)
        {
            if (empty)
            {
                front = new Node(d);
                empty = false;
            }
            else
            {
                getStrNodeAt(end).setNext(new Node(d));
            }

            end++;
        }

        public void sortAdd(int name)
        {
            if (empty)
            {
                add(name);
            }
            else
            {
                bool doIt = true;
                for (int i = 0; i <= end; i++)
                {
                    if (getAt(i) > name)
                    {
                        if (i == 0)
                        {
                            Node tmp = front;
                            front = new Node(name);
                            front.setNext(tmp);
                            end++;
                        }
                        else
                        {
                            insertAfter(i - 1, name);
                        }
                        doIt = false;
                        break;
                    }

                    comps++;
                }

                if (doIt)
                {
                    add(name);
                }
            }
        }

        public void printList()
        {
            Console.WriteLine();
            for (int i = 0; getStrNodeAt(i) != null; i++)
            {
                Console.Write(getAt(i) + (getStrNodeAt(i + 1) != null ? ", " : ""));
                
            }
            Console.WriteLine();
        }

        public int getAt(int i)
        {
            return getStrNodeAt(i).getData();
        }

        public void setAt(int index, int val)
        {
            getStrNodeAt(index).set(val);
        }

        public Node getStrNodeAt(int i)
        {
            return i > 0 ? getStrNodeAt(--i).getNext() : front;
        }

        public int findTail()
        {
            return getAt(end);
        }
        
        public void insertAfter(int index, int value)
        {
            Node workingStrNode = getStrNodeAt(index);
            Node temp = workingStrNode.getNext();
            
            Node newStrNode = new Node(value);
            newStrNode.setNext(temp);
            
            workingStrNode.setNext(newStrNode);

            end++;
        }

        public void delAt(int index)
        {
            if (index == 0)
            {
                front = front.getNext();
            }
            else
            {
                getStrNodeAt(index - 1).setNext(getStrNodeAt(index).getNext());
            }

            end--;

            if (end == -1)
            {
                empty = true;
            }
        }

        public List returnSort()
        {
            List returnList = new List();
            //int length = end;
            for (int i = 0, loop = end; i <= loop; i++)
            {
                int leastIndex = 0;
                for (int j = 0; j <= end; j++)
                {
                    if (getAt(j) < getAt(leastIndex))
                    {
                        leastIndex = j;
                    }
                }
                returnList.add(getAt(leastIndex));
                delAt(leastIndex);
            }

            return returnList;

        }
        
        public void bubbleThisSort()
        {
            bool swapping = true;
            while(swapping)
            {
                swapping = false;
                for (int j = 0; j <= end-1; j++)
                {
                    if (getAt(j) > getAt(j+1))
                    {
                        swapping = true;

                        int tmp = getAt(j);
                        
                        setAt(j, getAt(j+1));
                        
                        setAt(j+1, tmp);
                    }
                }
            }

        }
        
        public void thisSort()
        {
            List tmp = returnSort();
            for (int i = 0; i <= tmp.getEnd(); i++)
            {
                add(tmp.getAt(i));
            }
        }

        public int getEnd()
        {
            return end;
        }

        public int[] ToArray()
        {
            ArrayList returnArr = new ArrayList();
            for (int i = 0; i < end; i++)
            {
                returnArr.Add(getAt(i));
            }

            return (int[])returnArr.ToArray(typeof(int));
        }

        public int getComps()
        {
            return comps;
        }
    }
    
    
//********************************************************************************************************************************    
    

    public class Node
    {
        private int data;
        private Node next;
        
        public Node(int d)
        {
            data = d;
            next = null;
        }

        public Node getNext()
        {
            return next;
        }
        public void setNext(Node d)
        {
            next = d;
        }

        public void set(int val)
        {
            data = val;
        }

        public int getData()
        {
            return data;
        }
    }
}