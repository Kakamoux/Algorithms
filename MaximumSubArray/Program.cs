using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArray
{
    class Program
    {

        static void findHighest(int[] array)
        {
            int start = 0;
            int end = 0;
            int max = int.MinValue, localmax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                localmax = localmax + array[i];
                if (localmax > max)
                {
                    end = i;
                    max = localmax;
                }
               else if (localmax < 0)
                {
                    start = i;
                    localmax = 0;
                }
            }
            for (int i = start; i <= end; i++)
            {
                Console.Write(array[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine(max);
        }


        static void Main(string[] args)
        {
            int[] array = new int[] { -2, 1, -3, 4, -1, 2, 1, - 5, 4 };
            findHighest(array);
            Console.ReadLine();
        }
    }
}
