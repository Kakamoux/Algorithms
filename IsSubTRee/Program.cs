using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSubTRee
{
    class Program
    {
        class Node
        {
            public int Value { get; }
            public List<Node> nodes { get; }
            public Node(int value)
            {
                this.Value = value;
                nodes = new List<Node>();
            }
            public Node add(Node n)
            {
                nodes.Add(n);
                return this;
            }
        }
        static bool isSubTree(Node tree, Node sub)
        {
            if (tree == sub) return true;
            bool found = false;
            foreach (Node n in tree.nodes)
                found = found || isSubTree(n, sub);
            return found;
        }

       static bool isSubTree2(Node tree, Node sub)
        {
            List<List<Node>> tocheck = new List<List<Node>>();
            List<List<Node>> toadd = new List<List<Node>>();
            tocheck.Add( tree.nodes);
            if (tree == sub) return true;
            while (tocheck.Count >0)
            {
                foreach(List<Node> l in tocheck)
                {
                    foreach (var n in l)
                    {
                        if (n == sub) return true;
                        toadd.Add(n.nodes);
                    }
                    
                    
                }
                tocheck = new List<List<Node>>( toadd);
                toadd.Clear();
            }
            return false;
        }
        static void Main(string[] args)
        {
            Node a = new Node(1);
            Node root = new Node(2);
            root.add(a.add(new Node(4)).add(new Node(5)).add(new Node(6)));
            root.add(new Node(7).add(new Node(8)).add(new Node(9)).add(new Node(10)));
            root.add(new Node(11).add(new Node(12)).add(new Node(13)).add(new Node(14)));
            Node test = new Node(2);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(isSubTree(root, test));
            Console.WriteLine(isSubTree(root, a));
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine(isSubTree2(root, test));
            Console.WriteLine(isSubTree2(root, a));
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            Console.ReadLine();


        }
    }
}
