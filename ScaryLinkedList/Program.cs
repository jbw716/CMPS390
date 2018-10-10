using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(){
            linkedList test = new linkedList();
            var fileStream = new FileStream(@"names.txt", FileMode.Open, FileAccess.Read);
            node current = test.front;
            //int inputCode;
            using (var streamReader = new StreamReader(fileStream)){
                string line;
                int inputCode;
                //int currentCode;
                while ((line = streamReader.ReadLine()) != null){
                    inputCode = test.makeNameCode(line);
                    //currentCode = test.makeNameCode(current.name);
                    /*if(inputCode < currentCode){
                        //test.addBefore(line, current);
                    }
                    else if(inputCode > currentCode){
                        //test.addAfter(line, current);
                        //while(current.next.name <)
                    }*/
                    //test.add(line);
                    //Console.WriteLine(test.makeNameCode(line));
                }
            }
            test.test();
            test.print();
        

         



        //for(int i = 0; i < 5; i++){
        //    test.addLast(i.ToString());
        //}
        //test.print();
        //Console.WriteLine("\nnow reverse\n");
        //test.reverse();
        //test.sortAlphabetical();
       // Console.Write("Sum of x + y = "+ z);
    }
}
    public class node{
        public string name;
        public node next;
    }
    
    public class linkedList{
        public node front;
        
        public linkedList(){
            front = null;
        }
        
        public void print(){
            node current = front;
            while (current != null){
                Console.WriteLine(current.name);
                current = current.next;
            }
        }

        node makeNode(string data, node next){
            node returnMe = new node();
            returnMe.name = data;
            returnMe.next = next;
            return returnMe;
        }
        public void addNodeAtEndOfList(string data){
            if(front != null){
                node tail = findTail();
                tail.next = makeNode(data, null);
            }else{
                front = makeNode(data, null);
            }
        }
        node findTail(){
            node current = front;
            while(current.next != null){
                 current = current.next;
            }
            return current;
        }
        public int makeNameCode(string name){
            int code = (
                ((name[0]-'a')*26^2) + 
                ((name[1]-'a')*26^1) +
                ((name[2]-'a')*26^0)
            );
            return code;
        }
    
        public void add(string data) {
            node current = front;
            if (current != null){
                addLast(data);
            }else{
                addFirst(data);
            } 
        }
        public void addFirst(string data){
            node toAdd = new node();
            toAdd.name = data;
            toAdd.next =  front;
            // traverse all nodes (see the print all nodes method for an example)
            front = toAdd;
        }
        public void addLast(string data){
            if (front == null)
            {
                front = new node();

                front.name = data;
                front.next = null;
            }
            else
            {
                node toAdd = new node();
                toAdd.name = data;

                node current = front;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }
        public void addBefore(string data, node goal){
            node current = front;
            node next = current.next;
            //node before = null;
            node toAdd = new node();
            toAdd.name = data;
            while (current != null){
                if(goal != front){
                    if(next.name == goal.name){
                        //result = current;
                        current.next = toAdd;
                        toAdd.next = goal;
                        break;
                    }
                }
                current = current.next;
                next = current.next;
            }
        }
        public void addAfter(string data, node goal){
            
            node current = front;
            node next;// = current.next;
            //node before = null;
            node toAdd = new node();
            toAdd.name = data;
            while (current != null){
                //if(goal != front){
                    if(current.next.name == goal.name){
                        //result = current;
                        current.next = toAdd;
                        toAdd.next = goal;
                        //var x = current.next.name;
                        break;
                    }
            // }
                current = current.next;
                next = current.next;
            }
        }
        public void sortAlphabetical(){
            node current = front;
            node next = current.next;
            //node before;
            while (current != null){
                if(this.makeNameCode(current.name) > this.makeNameCode(next.name)){
                // before = findBefore(current);
                    //before.next = next;
                    next.next = current;
                    current.name = next.name;
                }


                current = next;
            }
        }
        public void reverse(){
            node current = front;
            node prev = this.findTail();
            while(prev != front){
                current = front;
                Console.WriteLine(prev.name);
                while(current.next != prev){
                    current=current.next;
                }
                prev=current;
            }
            //Console.WriteLine(prev.name);
        }

        public void test(){
            int[] seed = {6,3,7,1,8,2,9,4,0,5};
            node current = front;
            node addAfterMe = front;
            for(int i = 0; i < 10; i++){
                if(current == front){
                    current = makeNode(seed[i].ToString(),null);
                    Console.WriteLine("front probably");
                }
                else{
                    do{
                        
                        if(Int32.Parse(current.name) > seed[i]){
                            addAfterMe = current;
                            Console.WriteLine("the rest probably " + i);
                        }
                        current = current.next;
                        if(current == null){
                            break;
                        }
                    }while(current.next != null);
                    addAfter(seed[i].ToString(), addAfterMe);
                }
            }
        }
    }
}

