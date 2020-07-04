using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class SearchingAlgorithms
    {

        /* Finds the maximum integer value between a given range.
         */
        public static int FindMax(int[] arr, int from, int to)
        {
            int maxpos = from, n = arr.Length;
            if (from >= 0 && to < n)
            {
                for (int i = from; i <= to; i++)
                    if (arr[i] > arr[maxpos])
                        maxpos = i;
                return arr[maxpos];
            }
            else
            {
                return -1;
            }
        }

        /* Finds the minimum value between a given range.
         */
        public static int FindMin(int[] arr, int from, int to)
        {
            int minpos = from, n = arr.Length;
            if (from >= 0 && to < n)
            {
                for (int i = from; i < to; i++)
                    if (arr[i] < arr[minpos])
                        minpos = i;
                return arr[minpos];
            }
            else
            {
                return -1;
            }
        }

        /* Finds the minimum value in the array.
         */
        public static int FindMin(int[] arr)
        {
            int minpos = 0, n = arr.Length;
            for (int i = 1; i < n; i++)
                if (arr[i] < arr[minpos])
                    minpos = i;
            return arr[minpos];
        }

        /* Finds the maximum value in the array
         */
        public static int FindMax(int[] arr)
        {
            int maxpos = 0, n = arr.Length;
            for (int i = 1; i < n; i++)
                if (arr[i] > arr[maxpos])
                    maxpos = i;
            return arr[maxpos];
        }

        /* Finds an element in a sorted array using binary search algorithm.
         */
        public static int BinarySearch(int[] arr, int x)
        {

            int n = arr.Length;
            int left = 0, right = n - 1, center;
            center = (left + right) / 2;
            while ((left <= right) && (arr[center] != x))
            {
                if (x > arr[center])
                {
                    left = center + 1;
                }
                else
                {
                    right = center - 1;
                }
                center = (left + right) / 2;
            }
            if (left > right)
            {
                return -1;
            }
            return center;

        }

        /* Finds an element in an array using linear search algorithm.
         */
        public static int LinearSearch(int[] arr, int x)
        {
            int n = arr.Length;
            int i = 0;
            while (i < n && arr[i] != x)
                i++;
            if (i >= n)
            {
                return -1;
            }
            else
            {
                return i;
            }
        }

        /* Finds the median value in the array
         * Median value is the value that would be in the middle of the array if it were to be sorted
         */
        public static int FindMedian(int[] arr)
        {
            int n = arr.Length;
            int[] s = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        s[i]++;
                    }
                    else
                    {
                        s[j]++;
                    }
                }
            }
            int a = 0;
            while (s[a] != n / 2)
            {
                a++;
            }
            return arr[a];
        }

        /* Finds the avarage of the array
         */
        public static decimal FindAvarage(int[] arr)
        {
            int n = arr.Length;
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            return sum / (decimal)n;
        }

        /* Returns true or false depending on if the array has a recurring element
         */
        public static bool HasRecurrence(int[] arr)
        {
            int n = arr.Length, control, k = 0;
            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                control = LinearSearch(b, arr[i]);
                if (control == -1)
                {
                    b[k] = arr[i];
                    k++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /* Finds the most recurring element in the array
         */
        public static int FindMostRecurringElement(int[] arr)
        {
            int n = arr.Length;
            int k = 0, control;
            int[] kinds = new int[n];
            int[] counts = new int[n];
            for (int i = 0; i < n; i++)
            {
                control = LinearSearch(kinds, arr[i]);
                if (control == -1)
                {
                    kinds[k] = arr[i];
                    counts[k]++;
                    k++;
                }
                else
                {
                    counts[control]++;
                }
            }
            return kinds[LinearSearch(counts, FindMax(counts))];
        }

    }
}
