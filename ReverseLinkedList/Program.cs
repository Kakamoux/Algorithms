using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
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


        static Node reverse(Node a)
        {
            Node prev = a.Next;
            Node n = a;
            while(prev!=null)
            {

                Node d = prev.Next;
                prev.Next = n;

                n = prev;
                prev = d;

            }

            a.Next = null;
            return n;
        }

        static void Main(string[] args)
        {
            Node a = new Node(0);
            a.Next = new Node(1);
            a.Next.Next = new Node(2);
            a.Next.Next.Next = new Node(4);
            a.Next.Next.Next.Next = new Node(6);

            Node c = a;
            while (c != null)
            {
                Console.WriteLine("{0}", c.Value);
                c = c.Next;
            }

            Console.WriteLine("Begin reverse");
             a = reverse(a);
            Console.WriteLine("End reverse");


            while (a != null)
            {
                Console.WriteLine("{0}", a.Value);
                a = a.Next;
            }
            Console.ReadLine();
        }
    }
}
