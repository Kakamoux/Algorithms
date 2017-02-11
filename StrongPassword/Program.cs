using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPassword
{
    class Program
    {
        static Dictionary<char, char> charset = new Dictionary<char, char>();
        class Node
        {
            public char Value { get; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public Node(char value)
            {
                this.Value = value;
                this.Right = null;
                this.Left = null;
            }
        }

        static List<String> strongify(String str,String suffix = "")
        {
            List<String> suggest = new List<string>();
            char[] input = str.ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if(charset.ContainsKey(input[i]))
                {
                    suggest.AddRange(strongify(str.Substring(i+1,str.Length-(i+1)), suffix+str.Substring(0, i+1)));
                    input[i] = charset[input[i]];
                    suggest.Add(suffix + new String(input));
                    
                }
            }
            return suggest;
        }

        static Node strongify2(String str)
        {
            Node head = new Node(str[0]);
            List<Node> currents = new List<Node>();
            List<Node> tmps = new List<Node>();
            currents.Add(head);
            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                foreach (Node n in currents)
                {
                    Node r = charset.ContainsKey(c) ? new Node(charset[c]) : null;
                    Node l = new Node(c);
                    n.Right = r;
                    n.Left = l;
                    if(r!=null)
                     tmps.Add(r);
                    tmps.Add(l);
                }
                currents.Clear();
                currents.AddRange(tmps);
                tmps.Clear();
            }

            return head;

        }

        static void print(Node head,StringBuilder s)
        {

            s.Append(head.Value);

            if(head.Left!=null)
                print(head.Left, new StringBuilder(s.ToString()));
            if (head.Right != null)
                print(head.Right, new StringBuilder(s.ToString()));
            if(head.Left == null && head.Right == null)
            Console.WriteLine(s.ToString());
            
        }

        static void Main(string[] args)
        {
            charset.Add('i', '!');
            charset.Add('a', '@');
            charset.Add('s', '$');
            charset.Add('o', '0');
            charset.Add('e', '3');

            /*List<String> suggests = strongify("password");
            foreach (var item in suggests)
            {
                Console.WriteLine(item);
            }*/
            Node head = strongify2("password");
            print(head, new StringBuilder());
            Console.ReadLine();
        }
    }
}
