using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMirror
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

        static bool  isChildMirror(Node left, Node right)
        {
            if (!isNodeEqual(left.Left, right.Right)) return false;
            if (!isNodeEqual(left.Right, right.Left)) return false;
            return true;

        }

        static bool isNodeEqual(Node n, Node n2)
        {
            if (n == null && n2 != null) return false;
            if (n2 == null && n != null) return false;
            if (n == null && n2 == null) return true;
            return n.Value == n2.Value;
        }

        static bool isMirror(Node head)
        {
            List<Node> toCheck = new List<Node>();
            List<Node> toAdd = new List<Node>();
            toCheck.Add(head.Left);
            toCheck.Add(head.Right);
            bool c = true;
            if (!isNodeEqual(head.Left, head.Right)) return false;

            while (c)
            {
                c = false;
                toAdd.Clear();
                for (int i = 0; i < toCheck.Count; i++)
                {
                    if (i < toCheck.Count / 2)
                    {
                        if (!isNodeEqual(toCheck[i], toCheck[(toCheck.Count - 1) - i])) return false;
                        if(toCheck[i]!=null)
                            if (!isChildMirror(toCheck[i], toCheck[(toCheck.Count - 1) - i])) return false;
                    }

                    if (toCheck[i].Left != null)
                    {
                        c = true;
                        toAdd.Add(toCheck[i].Left);
                    }
                    if (toCheck[i].Right != null)
                    {
                        toAdd.Add(toCheck[i].Right);
                        c = true;
                    }
                    
                    

                }
                toCheck.Clear();
                toCheck.AddRange(toAdd);
            }
            return true;

        }

        static void Main(string[] args)
        {
            Node head = new Node(1);
            head.Left = new Node(3);
            head.Right = new Node(3);

            head.Left.Left = new Node(8);
            head.Left.Left.Left = new Node(8);

            head.Left.Right = new Node(9);
            head.Right.Left = new Node(9);
            head.Right.Right = new Node(8);

            head.Right.Right.Right = new Node(8);

            head.Left.Right.Left = new Node(11);
            head.Right.Left.Right = new Node(11);

            head.Left.Right.Left.Left = new Node(18);
            head.Right.Left.Right.Right = new Node(18);


            Console.WriteLine(isMirror(head));
            Console.ReadLine();
        }
    }
}
