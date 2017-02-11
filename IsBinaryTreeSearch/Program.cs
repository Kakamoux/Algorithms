using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    class Node
    {
        public int Value { get; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public Node(int value)
        {
            this.Value = value;
            this.Right = null ;
            this.Left = null;
        }
    }
    class Program
    {

       static bool isBinarySearchTree(Node node, int min, int max)
        {
            if(node != null)
            {
                if (node.Value > max || node.Value < min)
                    return false;
                return isBinarySearchTree(node.Left, min, node.Value) && isBinarySearchTree(node.Right, node.Value, max);

            }else
            {
                return true;
            }
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

            Console.WriteLine(" Binary search tree ? {0}", isBinarySearchTree(root, int.MinValue, int.MaxValue));

            Console.ReadLine();
        }
    }
}
