using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSquareRoot
{
    class Program
    {

        static double sqrt(double number)
        {
            double start = 0, end = number, mid = (start + end) / 2.0f, prevMid = 0, precision = 0.000000000005;
            while(mid*mid!=number && Math.Abs(mid-prevMid) > precision)
            {
                if(mid*mid > number)
                {
                    end = mid;
                    prevMid = mid;
                    mid = (start + end) / 2.0f;
                }
                else
                {
                    start = mid;
                    prevMid = mid;
                    mid = (start + end)  / 2.0f;
                }
            }

            return mid;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Square root of {0} is {1}", 1024, sqrt(1024));
            Console.WriteLine("Square root of {0} is {1}", 2, sqrt(2));
            Console.ReadLine();
        }
    }
}
