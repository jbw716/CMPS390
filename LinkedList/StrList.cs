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
        public int[] indexArr;

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
            
            /*if (i > 0)
            {
                return getStrNodeAt(--i).getNext();
            }
            else
            {
                return front;
            }*/
            
            

            /*StrNode Strnode = front;
            
            for (int j = 0; j < i; j++)
            {
                Strnode = Strnode.getNext();
            }

            return Strnode;*/
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

        public StrList otherSort()
        {
            StrList temp = new StrList();
            for (int i = 0; i < end; i++)
            {
                string val = null;
                int valIndex = 0;
                for (int j = 0; j < end; j++)
                {
                    if (val == null || (val[0] + val[1] + val[2]) <= (getAt(j)[0] + getAt(j)[1] + getAt(j)[2]))
                    {
                        val = getAt(j);
                        valIndex = j;
                    }
                }
                //Console.WriteLine("Deleting " + getAt(valIndex));
                delAt(valIndex);
                //Console.WriteLine("Val is " + val);
                temp.add(val);
            }

            return temp;
        }

        public void sortAlpha()
        {
            //StrList sorted = new StrList();
            /*for (int k = 2; k >= 0; k--)
            {*/
                int count = 0;
                for (char j = 'a'; j <= 'z'; j++)
                {
                    //Console.WriteLine(j);
                    for (int i = 0; i <= end; i++)
                    {
                        //if(j == 'b') Console.WriteLine(getAt(i) + " starts with " + j + " is " + (getAt(i).StartsWith(j)));
                        //if (getAt(i)[k] == j)
                        if(getAt(i).StartsWith(j))
                        {
                            //Console.WriteLine(getAt(i));
                            string temp = getAt(count);
                            setAt(count, getAt(i));
                            count++;
                            setAt(i, temp);
                        }
                    }
                }
            //}

            bool loop = true;
            
            while (loop)
            {
                loop = false;
                for (int i = 0; i <= end; i++)
                {
                    StrNode checkPrev = getStrNodeAt(i - 1);
                    StrNode check = getStrNodeAt(i);
                    StrNode checkNext = getStrNodeAt(i).getNext();
                    //StrNode nextNext = getStrNodeAt(i + 1).getNext();
                    if (checkNext != null && ((checkNext.getData()[0] + checkNext.getData()[1] + checkNext.getData()[2]) < (check.getData()[0] + check.getData()[1] + check.getData()[2])))
                    {
                        loop = true;
                        /*StrNode temp = getStrNodeAt(i).getNext().getNext();
                        getStrNodeAt(i).getNext().setNext(getStrNodeAt(i));
                        getStrNodeAt(i).setNext(temp);*/
                        
                        
                        /*getStrNodeAt(i-1).setNext(getStrNodeAt(i).getNext());
                        getStrNodeAt(i).setNext(getStrNodeAt(i+1).getNext());
                        getStrNodeAt(i+1).setNext(getStrNodeAt(i));*/
                        
                        
                        /*getStrNodeAt(i+1).setNext(check);
                        getStrNodeAt(i).setNext(nextNext);
                        getStrNodeAt(i-1).setNext(checkNext);*/

                        string tmp = getAt(i);
                        getStrNodeAt(i).set(getAt(i+1));
                        getStrNodeAt(i+1).set(tmp);
                    }
                }
            }

            /*for (int i = 0; i <= end; i++)
            {
                if (getStrNodeAt(i).getNext() != null && getAt(i).StartsWith(getAt(i + 1)))
                {
                    string temp = getAt(i + 1);
                    setAt(i+1, getAt(i));
                    setAt(i, temp);
                }
            }*/

            //Console.WriteLine("\n\n");
        }
        public int makeNameCode(string name){
            int code = (
                ((name[0]-'a')*26^2) + 
                ((name[1]-'a')*26^1) +
                ((name[2]-'a')*26^0)
            );
            return code;
        }

        public StrList yetAnotherSort()
        {
            StrList returnList = new StrList();
            StrNode current = front;
            int length = end;
            StrNode least = getStrNodeAt(0);
            int leastIndex = 0;
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= end; j++)
                {
                    if (makeNameCode(getAt(j)) < makeNameCode(least.data))
                    {
                        least = getStrNodeAt(j);
                        leastIndex = j;
                    }
                }
                delAt(leastIndex);
                returnList.add(least.data);
            }

            return returnList;

        }
        
        public void sortAlphabetical()
        {
            StrNode prev = null;
            StrNode current = front;
            StrNode next = current.next;
            //Console.WriteLine(getStrNodeAt(end).next == null);
            //node before;
            for (int i = 0; i <= end; i++)
            {
                if(this.makeNameCode(current.data) >= this.makeNameCode(next.data)){
                    // before = findBefore(current);
                    //before.next = next;
                    if (i != 0)
                    {
                        prev.next = next;
                        current.next = next.next;
                        next.next = current;
                    }
                    else
                    {
                        next.next = front;
                        front = next;
                    }
                    //current.data = next.data;
                }

                prev = current;
                current = next;
                next = current.next;
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