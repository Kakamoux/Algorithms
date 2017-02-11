using System;


namespace SimpleHashTable
{

    class Node
    {
        public Object Value { get; set; }

        public Object Key { get; set; }
        public Node Next { get; set; }

        public Node(Object k, Object v)
        {
            Value = v;
            Key = k;
            Next = null;
        }
    }

    public class HashTable
    {
        public int ColNumber { get; set; }
        int capacity;
        Node[] items;
        public HashTable(int capacity)
        {
            this.capacity = capacity;
            this.items = new Node[capacity];
            ColNumber = 0;
        }

        int hash(Object key)
        {
            return  Math.Abs( key.GetHashCode() % capacity);
        }

        public bool add(Object key, Object item)
        {
            int idx = hash(key);
            if (items[idx] == null)
            {
                items[idx] = new Node(key, item);
                return true;
            }else
            {
                Node n = new Node(key, item);
                Node tmp = items[idx];
                n.Next = tmp;
                items[idx] = n;
                ColNumber++;
                return false;
            }
            
        }

        public Object get(Object key)
        {
            int idx = hash(key);
            if (items[idx] != null)
            {
                Node n = items[idx];
                while(n!= null)
                {
                    if (n.Key == key)
                        return n.Value;
                    n = n.Next;
                }

                return null;
            }
            return null;
        }
       
        public bool remove(Object key)
        {
            int idx = hash(key);
            if (items[idx] != null)
            {
                Node n = items[idx];
                Node prev = null;
                while (n != null )
                {
                    if(n.Key == key)
                    {
                        if(n.Next!=null)
                        {
                            if(prev!=null)
                            {
                                prev.Next = n.Next;
                            }else
                            {
                                items[idx] = n.Next;
                            }
                        }
                        n = null;
                        return true;
                    }

                    prev = n;
                    n = n.Next;
                }
                return false;
            }
            return false;
        }
    }

    class Program
    {


 

        static void Main(string[] args)
        {
            HashTable hashtable = new HashTable(1000);
            for (int i = 0; i < 1000; i++)
            {
                String t = "test" + i;
                hashtable.add(t, t + "Value");
                String v = (String)hashtable.get(t);
                if (v != t + "Value") Console.WriteLine("PAS BONNNNNNNNNNNNN !!!!!!!!!!!!!!!!!!!!!");
                else Console.WriteLine("key {0} value {1}", t, v);
            }
            Console.WriteLine("ColNumber {0}", hashtable.ColNumber);
            Console.ReadLine();
        }
    }
}
