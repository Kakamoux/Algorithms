using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeToArray
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


        static Node toBTS(int[] sortedArray, int start , int end)
        {

            int mid = (int)Math.Ceiling(((end - start) / 2.0f) + start);
            Node n = new Node(sortedArray[mid]);
            if(start-mid!=0)
            {
                n.Left = toBTS(sortedArray, start, mid-1);
            }
            if(end-mid !=0)
            {
                n.Right = toBTS(sortedArray, mid+1, end);
            }

            return n;
        }

       static int toArray(Node root, int[] a, int pos = 0)
        {
            if(root.Left!=null)
                pos = toArray(root.Left, a, pos);
            a[pos++] = root.Value;
            if (root.Right != null)
                pos = toArray(root.Right, a, pos);
            return pos;
        }

       

        static void Main(string[] args)
        {
            int[] sortedArray = new int[] { 0,1,2,3,4,5,6,7,8,9,10};
            Node head= toBTS(sortedArray, 0, sortedArray.Length-1);
            int[] a = new int[11];
            toArray(head,a);
            foreach (var item in a)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();    
            Console.ReadLine();
        }
    }
}
