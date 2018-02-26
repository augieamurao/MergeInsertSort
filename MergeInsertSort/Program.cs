using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    class Program
    {
        static void Main(string[] args)
        {
            //To dos:
            // 

            Console.WriteLine("Starting insert sort...");

            int[] input = { 6, 9, 2, 1, 5, 7, 2, 8, 6, 3, 0, 4 };
            //int[] input = { 6,2,8,4 };


            //InsertSorter.sortArray(input);
            MergeSorter.sortArray(input);
 
            // Print out array
            Boolean firstItem = true;
            foreach (int j in input)
            {
                if (firstItem)
                {
                    firstItem = false;
                }
                else
                {
                    Console.Write(",");
                }
                Console.Write("{0}", j);
            }
            Console.WriteLine("");
            Console.WriteLine("Sort is complete.");
            Console.ReadLine();


        }
    }

    class MergeSorter
    {
        static public void sortArray(int[] input)
        {
            int r = input.Length - 1;
            mergeSort(input, 0, r);
        }

        static public void mergeSort(int[] arr, int p, int r)
        {
            // p is start index, r is last index, q is split index
            // first half is p -> q; send half is q+1 -> r
            if (r > p)
            {
                int q = p + (r - p) / 2;
                mergeSort(arr, p, q);
                mergeSort(arr, q + 1, r);
                merge(arr, p, q, r);
            }  
        }
         
        static public void merge(int [] arr, int p, int q, int r)
        {
            int[] left = new int[(q-p+1)+1];                // add additional slot for sentinel value
            Array.Copy(arr, p, left, 0, (q-p)+1);
            left[left.Length - 1] = Int32.MaxValue;      // sentinel value
            

            int[] right = new int[(r - q)+1];   // add additional slot for sentinel value
            Array.Copy(arr, q+1, right, 0, (r - q));
            right[right.Length - 1] = Int32.MaxValue;   //sentinel value

            int i = 0;          // index into left array
            int j = 0;      // index into right array
            int k = p;          // index into result
            for (k = p; k <= r; k++)
            {
                    if (left[i] <= right[j])
                    {
                        arr[k] = left[i];
                        ++i;
                    }
                    else
                    {
                        arr[k] = right[j];
                        ++j;
                    }

            }
        }

    }
    class InsertSorter
    {
        static public void sortArray(int[] input)
        {
            for (int j = 1; j < input.Length; ++j)        //Note: start at the second item
            {
                for (int i = j - 1; i >= 0; --i)
                {
                    if (input[i + 1] < input[i])
                    {
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;

                    }
                }
            }
        }
    }
}
