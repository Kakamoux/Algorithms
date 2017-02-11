using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSmallerElement
{
    class Program
    {

        class Node
        {
            public int Value { get; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public Node(int value)
            {
                this.Value = value;
                this.Right = null;
                this.Left = null;
            }
        }

        static Node getNthSmallerElement(Node head)
        {
            Node h = head;
            Node min = head;
            //TODO


        }

        static void Main(string[] args)
        {
            Node root = new Node(20);
            root.Left = new Node(10);
            root.Right = new Node(30);
            root.Left.Left = new Node(5);
            root.Left.Right = new Node(15);
            root.Right.Left = new Node(25);
            root.Right.Right = new Node(35);
            //TODO
        }
    }
}
