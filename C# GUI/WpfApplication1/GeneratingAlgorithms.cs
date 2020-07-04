using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class GeneratorAlgorithms
    {
        private static Random r = new Random();
        /* Generates a sorted & descending array
         */
        public static int[] SortedDescendingArray(int n, int max, int adder)
        {
            int[] arr = new int[n];
            arr[n - 1] = r.Next(max) + 1;
            for (int i = n - 2; i >= 0; i--)
            {
                arr[i] = arr[i + 1] + r.Next(adder) + 1;
            }
            return arr;
        }
        /* Generates a sorted & ascending array
         */
        public static int[] SortedAscendingArray(int n, int max, int adder)
        {
            int[] arr = new int[n];
            arr[0] = r.Next(max) + 1;
            for (int i = 1; i < n; i++)
            {
                arr[i] = arr[i - 1] + r.Next(adder) + 1;
            }
            return arr;
        }
        /* Generates a random array.
         */
        public static int[] RandomArray(int n, int max)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(max) + 1;
            }
            return arr;
        }
        /* Generates a random array with no recurring elements.
         */
        public static int[] RandomNoRecurrenceArray(int n, int max, int adder)
        {
            int[] arr = new int[n];
            int rdm_min, rdm_pos, coefficient, i = 0;
            rdm_min = r.Next(max) + 1;
            arr[r.Next(n)] = rdm_min;
            while (i < (n - 1))
            {
                rdm_pos = r.Next(n);
                if (arr[rdm_pos] == 0)
                {
                    coefficient = r.Next(adder) + 1;
                    rdm_min += coefficient;
                    arr[rdm_pos] = rdm_min;
                    i++;
                }
            }
            return arr;
        }
        /* Generates a random array where when the array is sorted 
         * difference between each consecutive element is a constant.
         */
        public static int[] SequentialArray(int n, int max, int adder)
        {
            int[] arr = new int[n];
            int rdm_min, rdm_pos, coefficient, i = 0;
            rdm_min = r.Next(max) + 1;
            coefficient = r.Next(adder) + 1;
            arr[r.Next(n)] = rdm_min;
            while (i < (n - 1))
            {
                rdm_pos = r.Next(n);
                if (arr[rdm_pos] == 0)
                {
                    rdm_min += coefficient;
                    arr[rdm_pos] = rdm_min;
                    i++;
                }
            }
            return arr;
        }
        /* Generates a random array where when the arrau is sorted
         * difference between each sorted element is a constant.
         */
        public static int[] IncrementialArray(int n, int max)
        {
            int[] arr = new int[n];
            int rdm_min, rdm_pos, coefficient, i = 0;
            rdm_min = r.Next(max) + 1;
            coefficient = 1;
            arr[r.Next(n)] = rdm_min;
            while (i < (n - 1))
            {
                rdm_pos = r.Next(n);
                if (arr[rdm_pos] == 0)
                {
                    rdm_min += coefficient;
                    arr[rdm_pos] = rdm_min;
                    i++;
                }
            }
            return arr;
        }
        /* Generates the well known fibonacci array
         * 1 1 2 3 5 8 13 21 ...
         */
        public static int[] FibonacciArray(int n)
        {
            int[] arr = new int[n];
            int num1 = 1; int num2 = 1;
            arr[0] = num1;
            arr[1] = num2;
            n -= 2;
            int p = 2;
            while (n > 0)
            {
                num2 = num1 + num2;
                num1 = num2 - num1;
                n--;
                arr[p] = num2;
                p++;
            }
            return arr;
        }
    }
}
