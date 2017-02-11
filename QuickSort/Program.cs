using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {

        static void sort(int[] arr, int left, int right)
        {
            int i = left, j = right, pivot = (left + right) / 2;
            while (i <= j)
            {
                while(arr[i]<arr[pivot])
                {
                    i++;
                }

                while(arr[j] > arr[pivot])
                {
                    j--;
                }

                if (i<=j)
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (i < right)
                sort(arr, i, right);
            if (j > left)
                sort(arr, left, j);
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 4,5,1,3,41,21,56,20,11,2,1,30 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            sort(arr, 0, arr.Length-1);
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
