using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubsetsOfStrings
{
    class Program
    {
        static void swap(ref char a, ref char b)
        {
            char c = a;
            a = b;
            b = c;
        }

        static void Permute(char[] str, int current, int length)
        {
            if(current==length)
            {
                Console.WriteLine(str);
                return;
            }
            for (int i = current; i <= length; i++)
            {
                swap(ref str[current], ref str[i]);
                Permute(str, current + 1, length);
                swap(ref str[current], ref str[i]);
            }
        }
        static void Main(string[] args)
        {
            String a = "abc";
            char[] arr = a.ToCharArray();
            Permute(arr, 0,a.Length-1);
            Console.ReadLine();
        }
    }
}
