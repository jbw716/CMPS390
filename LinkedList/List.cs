using System;

namespace q
{
    public class List
    {
        private Node front;
        private bool empty;
        private int end;

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
                getNodeAt(end).setNext(new Node(d));
            }

            end++;
        }

        public void printList()
        {
            for (int i = 0; getNodeAt(i) != null; i++)
            {
                Console.Write(getAt(i) + (getNodeAt(i + 1) != null ? ", " : ""));
                
            }
        }

        public int getAt(int i)
        {
            return getNodeAt(i).getData();
        }

        public Node getNodeAt(int i)
        {

            if (i > 0)
            {
                return getNodeAt(--i).getNext();
            }
            else
            {
                return front;
            }
            
            /*Node node = front;
            
            for (int j = 0; j < i; j++)
            {
                node = node.getNext();
            }

            return node;*/
        }

        public int findTail()
        {
            return getAt(end);
        }
        
        public void insertAfter(int index, int value)
        {
            Node workingNode = getNodeAt(index);
            Node temp = workingNode.getNext();
            
            Node newNode = new Node(value);
            newNode.setNext(temp);
            
            workingNode.setNext(newNode);
        }

        public void delAt(int index)
        {
            getNodeAt(index-1).setNext(getNodeAt(index).getNext());
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

        public int getData()
        {
            return data;
        }
    }
}