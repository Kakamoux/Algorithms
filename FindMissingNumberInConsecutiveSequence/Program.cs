using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMissingNumberInConsecutiveSequence
{
    //At least one positive integer
    class Program
    {

        static List<int> findMissingNumbers(List<int> l)
        {
            
            List<int> missings = new List<int>();
            if (l.Count < 1) return missings;
            int expected = l[0] + 1;
            for (int i = 1; i < l.Count; i++)
            {
                if (l[i] != expected)
                {
                    int to = expected;
                    to = l[i];
                    missings.AddRange(Enumerable.Range(expected, to-expected));
                    expected = to+1;
                }
                else expected++;


            }
            return missings;
        }


        static void print(List<int> l)
        {
            Console.Write("Missing numbers are : ");
            foreach (var item in l)
            {
                Console.Write("{0},", item);
            }
            Console.WriteLine();
        }

        static List<int> findingMissingNumbers2(List<int> l)
        {
            if (l.Count < 1) return new List<int>();
            return Enumerable.Range(l[0], l[l.Count - 1]).Except(l).ToList();
        }

        static void Main(string[] args)
        {
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };//empty
            List<int> b = new List<int>() { 2, 3,4,5,6,7,9,10,11,13}; //8,12
            List<int> c = new List<int>() { 2, 3, 4, 5, 6, 7, 9,  13,14}; //8, 10, 11, 12
            

            print(findMissingNumbers(a));
            print(findMissingNumbers(b));
            print(findMissingNumbers(c));

            print(findMissingNumbers(a));
            print(findMissingNumbers(b));
            print(findMissingNumbers(c));
            Console.ReadLine();
        }
    }
}
