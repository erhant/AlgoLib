using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ArrayAlgorithms
    {
        private static void swap(int[] arr, int i, int j)
        {
            int tmp;
            tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        public static void oddEvenParse(int[] arr)
        {

            int n = arr.Length;
            int oddL = 0, evenR = n - 1;
            bool swapmeL, swapmeR;
            while (oddL < evenR)
            {
                if (arr[oddL] % 2 == 1)
                {
                    oddL++;
                    swapmeL = false;
                }
                else
                {
                    swapmeL = true;
                }
                if (arr[evenR] % 2 == 0)
                {
                    evenR--;
                    swapmeR = false;
                }
                else
                {
                    swapmeR = true;
                }
                if (swapmeL && swapmeR)
                {
                    swap(arr, oddL, evenR);
                }
            }

        }

        public static void OddEvenParseHeaped(int[] arr)
        {

            int n = arr.Length;
            int oddL = 0, evenR = n - 1, limit;
            bool swapmeL, swapmeR;
            while (oddL < evenR)
            {
                if (arr[oddL] % 2 == 1)
                {
                    oddL++;
                    swapmeL = false;
                }
                else
                {
                    swapmeL = true;
                }
                if (arr[evenR] % 2 == 0)
                {
                    evenR--;
                    swapmeR = false;
                }
                else
                {
                    swapmeR = true;
                }
                if (swapmeL && swapmeR)
                {
                    swap(arr, oddL, evenR);
                }
            }
            int i, p;
            i = 0;
            while (arr[i] % 2 == 1)
            {
                i++;
            }
            limit = i;
            int[] tmparrodd = new int[limit];
            int[] tmparreven = new int[n - limit];
            i = 0;
            p = 0;
            while (arr[i] % 2 == 1)
            {
                tmparrodd[p] = arr[i];
                p++; i++;
            }
            SortingAlgorithms.SelectionSortAscending(tmparrodd);
            i = 0; p = 0;
            while (arr[i] % 2 == 1)
            {
                arr[i] = tmparrodd[p];
                i++; p++;
            }

            p = 0; limit = i;
            while (i < n)
            {
                tmparreven[p] = arr[i];
                p++; i++;
            }
            SortingAlgorithms.SelectionSortDescending(tmparreven);
            i = limit; p = 0;
            while (i < n)
            {
                arr[i] = tmparreven[p];
                i++; p++;
            }
        }

        public static int[] mergeArrays(int[] a, int[] b)
        {

            int n = a.Length, m = b.Length;
            int i = 0, j = 0, k = -1;
            int[] c = new int[n + m];

            while ((i < n) && (j < m))
            {
                k++;
                if (a[i] < b[j])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                }
            }

            while (i < n)
            {
                k++;
                c[k] = a[i];
                i++;
            }

            while (j < m)
            {
                k++;
                c[k] = b[j];
                j++;
            }
            return c;
        }

        public static int[] eliminateRecurrence(int[] arr)
        {
            int control, k = 0, n = arr.Length;
            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                control = SearchingAlgorithms.LinearSearch(b, arr[i]);
                if (control == -1)
                {
                    b[k] = arr[i];
                    k++;
                }
            }
            int[] c = new int[k];
            for (int i = 0; i < k; i++)
            {
                c[i] = b[i];
            }
            return c;
        }

        public static int[] eliminatePlateau(int[] arr)
        {
            int x = -1, k = 0, n = arr.Length;
            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != x)
                {
                    x = arr[i];
                    b[k] = x;
                    k++;
                }
            }
            int[] c = new int[k];
            for (int i = 0; i < k; i++)
            {
                c[i] = b[i];
            }
            return c;
        }

        public static void shuffleElements(int[] arr)
        {
            Random r = new Random();
            int n = arr.Length;
            int[] shuffler = new int[n];
            int rdm_min, rdm_pos, coefficient, i = 0;
            rdm_min = 0;
            coefficient = 1;
            shuffler[r.Next(n)] = 1;
            while (i < (n - 1))
            {
                rdm_pos = r.Next(n);
                if (shuffler[rdm_pos] == 0)
                {
                    rdm_min += coefficient;
                    shuffler[rdm_pos] = rdm_min;
                    i++;
                }
            }

            for (int j = 0; j < n; j++)
            {
                swap(arr, j, shuffler[j]);
            }
        }

        public static void rotateRight(int[] arr)
        {
            int n = arr.Length;
            int lift, put;
            lift = arr[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                put = lift;
                lift = arr[i];
                arr[i] = put;
            }
            arr[n - 1] = lift;
        }

        public static void rotateLeft(int[] arr)
        {
            int n = arr.Length;
            int lift, put;
            lift = arr[0];
            for (int i = n - 1; i > 0; i--)
            {
                put = lift;
                lift = arr[i];
                arr[i] = put;
            }
            arr[0] = lift;
        }

        public static void subRotateRight(int[] arr, int from, int to)
        {
            int lift, put;
            lift = arr[to];
            for (int i = from; i < to; i++)
            {
                put = lift;
                lift = arr[i];
                arr[i] = put;
            }
            arr[to] = lift;
        }

        public static void subRotateLeft(int[] arr, int from, int to)
        {
            int lift, put;
            lift = arr[from];
            for (int i = to; i > from; i--)
            {
                put = lift;
                lift = arr[i];
                arr[i] = put;
            }
            arr[from] = lift;
        }

        public static bool isSorted(int[] arr)
        {
            int n = arr.Length;
            if (n <= 2)
            {
                return true;
            }
            else
            {
                int i = 1;
                while (arr[i] != arr[0])
                {
                    i++;
                }
                if (arr[i] > arr[0])
                {
                    while (i < n && arr[i] >= arr[i - 1])
                    {
                        i++;
                    }
                    if (i == n)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    while (i < n && arr[i] <= arr[i - 1])
                    {
                        i++;
                    }
                    if (i == n)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
