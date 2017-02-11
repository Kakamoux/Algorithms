using System;
using SimpleHashTable;

namespace IsAlluniqueCharacters
{
    class Program
    {
        static bool isUnique(String str)
        {
            bool [] cs = new bool[256];
           
            foreach (char c in str)
            {
                if (cs[c]) return false;
                cs[c] = true;
            }
            return true;
        }


        static void Main(string[] args)
        {
            String a = "This is non unique";
            String b = "Unique yah";
            Console.WriteLine(isUnique(a));
            Console.WriteLine(isUnique(b));
            Console.ReadLine();
        }
    }
}
