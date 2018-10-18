using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;

namespace q
{
    public class StrList
    {
        private StrNode front;
        private bool empty;
        private int end;
        private int[] indexArr;

        public StrList()
        {
            empty = true;
            end = -1;
        }

        public void add(string d)
        {
            if (empty)
            {
                front = new StrNode(d);
                empty = false;
            }
            else
            {
                getStrNodeAt(end).setNext(new StrNode(d));
            }

            end++;
        }

        public void sortAdd(string name)
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
                    if (makeNameCode(getAt(i)) > makeNameCode(name))
                    {
                        if (i == 0)
                        {
                            StrNode tmp = front;
                            front = new StrNode(name)
                            {
                                next = tmp
                            };
                        }
                        else
                        {
                            insertAfter(i - 1, name);
                        }
                        doIt = false;
                        break;
                    }
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

        public string getAt(int i)
        {
            return getStrNodeAt(i).getData();
        }

        public void setAt(int index, string val)
        {
            getStrNodeAt(index).set(val);
        }

        public StrNode getStrNodeAt(int i)
        {
            return i > 0 ? getStrNodeAt(--i).getNext() : front;
        }

        public string findTail()
        {
            return getAt(end);
        }
        
        public void insertAfter(int index, string value)
        {
            StrNode workingStrNode = getStrNodeAt(index);
            StrNode temp = workingStrNode.getNext();
            
            StrNode newStrNode = new StrNode(value);
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

        public void index()
        {
            List<int> indexArrList = new List<int>();

            indexArrList.Add(0);

            int prevIndex = 0;

            for (int i = 1; i <= 25; i++)
            {
                for (int j = prevIndex; j <= end; j++)
                {
                    if (getAt(j)[0] != getAt(prevIndex)[0])
                    {
                        indexArrList.Add(j);
                        prevIndex = j;
                    }
                }
            }

            indexArr = indexArrList.ToArray();
        }

        public void printWithLetter(char letter)
        {
            int currentIndex = 0;
            int currentArrIndex = indexArr[currentIndex];
            for (int i = 0; i < indexArr.Length; i++)
            {
                if (getAt(indexArr[i])[0] == letter)
                {
                    currentIndex = i;
                    currentArrIndex = indexArr[i];
                    break;
                }
            }

            for (int i = currentArrIndex; i < ((getAt(currentArrIndex)[0] == 'z') ? (end + 1) : indexArr[currentIndex+1]); i++)
            {
                Console.WriteLine(getAt(i));
            }
        }

        public StrList yuckSort()
        {
            StrList returnList = new StrList();
            for (char i = 'a'; i <= 'z'; i++)
            {
                for (char j = 'a'; j <= 'z'; j++)
                {
                    for (char k = 'a'; k <= 'z'; k++)
                    {
                        for (int x = 0; x <= end; x++)
                        {
                            if (getAt(x)[0] == i && getAt(x)[1] == j && getAt(x)[2] == k)
                            {
                                returnList.add(getAt(x));
                            }
                        }
                    }
                }
            }
            return returnList;
        }

        public void lazySort()
        {
            ArrayList tmp = new ArrayList();
            for (int i = 0; i <= end; i++)
            {
                tmp.Add(getAt(i));
            }
            tmp.Sort();
            //string[] tmpArr = (string[])tmp.ToArray();
            for (int i = 0; i <= end; i++)
            {
                getStrNodeAt(i).set((string)tmp[i]);
            }
        }

        public int makeNameCode(string name){
            int code = (
                ((name[0]-'a')*(int)Math.Pow(26, 2)) + 
                ((name[1]-'a')*(int)Math.Pow(26, 1)) +
                ((name[2]-'a')*(int)Math.Pow(26, 0))
            );
            return code;
        }

        public StrList returnSort()
        {
            StrList returnList = new StrList();
            //int length = end;
            for (int i = 0, loop = end; i <= loop; i++)
            {
                int leastIndex = 0;
                for (int j = 0; j <= end; j++)
                {
                    if (makeNameCode(getAt(j)) < makeNameCode(getAt(leastIndex)))
                    {
                        leastIndex = j;
                    }
                }
                returnList.add(getAt(leastIndex));
                delAt(leastIndex);
            }

            return returnList;

        }
        
        public void thisSort()
        {
            StrList tmp = returnSort();
            for (int i = 0; i <= tmp.getEnd(); i++)
            {
                add(tmp.getAt(i));
            }
        }

        public int getEnd()
        {
            return end;
        }
    }
    
    
//********************************************************************************************************************************    
    

    public class StrNode
    {
        public string data;
        public StrNode next;
        public StrNode(string d)
        {
            data = d;
            next = null;
        }

        public StrNode getNext()
        {
            return next;
        }
        public void setNext(StrNode d)
        {
            next = d;
        }

        public void set(string val)
        {
            data = val;
        }

        public string getData()
        {
            return data;
        }
    }
}