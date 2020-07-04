using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class SortingAlgorithms
    {
        /* Sorts an array using the selection sort algorithm
         * This one makes it ascending.
         * 
         * Time Complexity : O(n^2)
         * Space Complexity : O(1)
         */
        public static void SelectionSortAscending(int[] arr)
        {
            int i, j, minIndex, tmp;
            int n = arr.Length;
            for (i = 0; i < n - 1; i++)
            {
                minIndex = i;
                for (j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                if (minIndex != i)
                {
                    tmp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = tmp;
                }
            }
        }

        /* Sorts an array using the selection sort algorithm
         * This one makes it descending.
         * 
         * Time Complexity : O(n^2)
         * Space Complexity : O(1)
         */
        public static void SelectionSortDescending(int[] arr)
        {

            int i, j, maxIndex, tmp;
            int n = arr.Length;
            for (i = 0; i < n - 1; i++)
            {
                maxIndex = i;
                for (j = i + 1; j < n; j++)
                    if (arr[j] > arr[maxIndex])
                        maxIndex = j;
                if (maxIndex != i)
                {
                    tmp = arr[i];
                    arr[i] = arr[maxIndex];
                    arr[maxIndex] = tmp;
                }
            }
        }

        /* Sorts an array using Bubble Sort algorithm
         * 
         * Time Complexity : O(n^2)
         * Space Complexity : O(1)
         */
        public static void BubbleSort(int[] arr)
        {

            int n = arr.Length;
            int tmp;
            bool ctrl = true;
            while (ctrl)
            {
                ctrl = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        ctrl = true;
                    }
                }
            }
        }

        /* Sorts an array using heap sort algorithm
         * Auxillary function "Heapify" is used
         * 
         * Time Complexity : O(nLogn)
         * Space Complexity : O(1)
         */
        public static void HeapSort(int[] arr)
        {

            int n = arr.Length;
            int i, tmp;
            // Build heap (rearrange array)
            for (i = (n / 2) - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // One by one extract an element from heap
            for (i = n - 1; i >= 0; i--)
            {
                // Swap current root with end
                tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;
                // call max heapify on the reduced heap
                Heapify(arr, i, 0);
            }
        }

        /* Sorts an array by calculating the position of every number
         * 
         * Time Complexity : O(n+k)
         * Space Complexity : O(k)
         */
        public static void LinearCountingSort_Score(int[] arr)
        {

            int n = arr.Length;
            int[] tmp = new int[n];
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
            // at this point we have the position that every number should go in the S array
            // making a sorted array out of the given array
            for (int i = 0; i < n; i++)
            {
                tmp[s[i]] = arr[i];
            }
            // transferring that sorted array back to our normal array
            for (int i = 0; i < n; i++)
            {
                arr[i] = tmp[i];
            }
        }

        /* Sorts an array by calculating the frequency of every element.
         * 
         * Time Complexity : O(n+k)
         * Space Complexity : O(k)
         */
        public static void LinearCountingSort_Freq(int[] arr)
        {

            int n = arr.Length;
            int min, max, i, j;

            min = arr[0];
            max = arr[0];
            for (i = 0; i < n; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                else
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
            }
            int[] f = new int[max - min + 1];
            for (i = 0; i < n; i++)
            {
                f[arr[i] - min]++;
            }
            j = 0;
            for (i = 0; i < f.Length; i++)
            {
                while (f[i] != 0)
                {
                    arr[j] = i + min;
                    j++;
                    f[i]--;
                }
            }

        }

        /* Auxillary function for HeapSort
         */
        private static void Heapify(int[] arr, int n, int i)
        {
            int tmp;
            int largest = i;  // Initialize largest as root
            int l = 2 * i + 1;  // left = 2*i + 1
            int r = 2 * i + 2;  // right = 2*i + 2

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                tmp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = tmp;
                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }

    }
}
