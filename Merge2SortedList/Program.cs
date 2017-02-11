using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge2SortedList
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
        

        static Node mergeLinked(Node a, Node b)
        {
            Node head = new Node(0);
            Node c = head;
            while (a!=null || b!=null)
            {
                if(a!=null && b!=null)
                {
                    if(a.Value < b.Value)
                    {
                        c.Next = a;
                        a = a.Next;
                    }
                    else if(a.Value > b.Value)
                    {
                        c.Next = b;
                        b = b.Next;
                    }else
                    {
                        a = a.Next;
                        b = b.Next;
                    }
                    c = c.Next;
                }
                else if(a==null)
                {
                    c.Next = b;
                    break;
                }else if(b == null)
                {
                    c.Next = a;
                    break;
                }
            }

            return head.Next ;
        }

        static void Main(string[] args)
        {

            Node a = new Node(0);
            a.Next = new Node(1);
            a.Next.Next = new Node(2);
            a.Next.Next.Next = new Node(4);
            a.Next.Next.Next.Next = new Node(6);

            Node b = new Node(1);
            b.Next = new Node(3);
            b.Next.Next = new Node(5);
            b.Next.Next.Next = new Node(6);
            b.Next.Next.Next.Next = new Node(7);
            b.Next.Next.Next.Next.Next = new Node(8);
            Console.WriteLine("Begin");
            Node c = mergeLinked(a, b);
            Console.WriteLine("Ended");
            while (c!=null)
            {
                Console.WriteLine("{0}", c.Value);
                c = c.Next;
            }
            Console.ReadLine();


        }
    }
}
