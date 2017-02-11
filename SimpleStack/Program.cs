using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStack
{
    class Program
    {

        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int v)
            {
                Value = v;
                Next = null;
            }
        }

        class Stack {
            Node head;
            Node min;
            public Stack()
            {
                head = null;
                min = null;
            }

            public void push(int value)
            {
                Node n = new Node(value);
                n.Next = head;
                head = n;
                if (min == null) min = new Node(value);
                else if (min.Value >= value)
                {
                    Node nm = new Node(value);
                    nm.Next = min;
                    min = nm;
                }

            }

            public int pop()
            {
                if(head!=null)
                {
                    Node n = head;
                    head = head.Next;
                    int v = n.Value;
                    n = null;
                    if (min != null) {
                        if (min.Value == v)
                        {
                            Node m = min;
                            min = min.Next;
                            m = null;
                        }
                    }
                    return v;
                }
                return new int(); // or throw error
            }

            public int val()
            {
                if (head == null) return new int(); //or throw error
                return head.Value;
            }
            public bool empty()
            {
                return head == null;
            }

            public int minVal()
            {
                if(min== null) return new int(); //or throw error
                return min.Value;
            }

            public void printStack()
            {
                Node h = head;
                Console.Write("{");
                while (h!=null)
                {
                    Console.Write("{0},",h.Value);
                    h = h.Next;
                }
                Console.Write("}");
            }
        }

        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.push(4);
            s.push(1);
            s.push(2);
            s.push(1);
            s.push(4);
            s.push(5);
            Console.Write("min {0} stack : ", s.minVal());
            s.printStack();
            Console.WriteLine("");
            while (!s.empty())
            {
                Console.Write("value {0} min {1} stack : ", s.pop(), s.minVal());
                s.printStack();
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
