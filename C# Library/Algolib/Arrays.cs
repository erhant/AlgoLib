using System;
using System.Collections.Generic;

/// <summary>
/// Most of the algorithms were written by hand by Erhan Tezcan. 
/// Help was taken from geeksforgeeks.com and "Teoriden Uygulamalara algoritmalar", Prof. Dr. Vasif NABIYEV, 5. Baski, Seckin Yayinevi
/// </summary>
namespace Algolib
{
    public class Arrays
    {
        /// <summary>
        /// Various sorting algorithms for double and int arrays.
        /// 
        /// Note that sorting algorithms can be seen under two categories:
        /// 1 - Comparison Based (applicable to anything with IComparable interface)
        /// 2 - Distribution Based (numbers only, at times integers only)
        /// </summary>
        public class Sorting
        {
            /// <summary>
            /// Sorts an array using the selection sort algorithm
            ///
            /// Time Complexity : O(n^2)
            /// Space Complexity : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void SelectionSort(double[] arr)
            {
                int i, j, minIndex;
                double tmp;
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

            /// <summary>
            /// Sorts an array using Bubble Sort algorithm
            /// 
            /// Time Complexity : O(n^2)
            /// Space Complexity : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void BubbleSort(double[] arr)
            {
                int n = arr.Length;
                double tmp;
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

            /// <summary>
            /// Comb Sort is an improvement over Bubble Sort. It improves the switching place part of the algorithm. 
            /// It was decided by experiments that shrinking factor should be 1.3 as a result of experiments.
            /// </summary>
            /// <param name="arr"></param>
            public static void CombSort(double[] arr)
            {
                int n = arr.Length;
                int gap = n; // this will be n/2 when the loop starts

                bool swapped = true;

                while (gap != 1 || swapped == true)
                {
                    gap = CombSortGetNextGap(gap);
                    swapped = false;
                    // Compare all elements wih current gap
                    for (int i = 0; i < n - gap; i++)
                    {
                        if (arr[i] > arr[i + gap])
                        {
                            Arrays.Miscellaneous.Swap(arr, i, i + gap);
                            swapped = true;
                        }
                    }
                }
            }
            private static int CombSortGetNextGap(int gap)
            {
                gap = (gap * 10) / 13; // shrink factor of 1.3 which is found by experimentation
                if (gap < 1) return 1;
                return gap;
            }

            /// <summary>
            /// Sorts an array using heap sort algorithm, also uses an auxillary function called Heapify.
            /// Heap Tree is used, unlike selection sort which finds max in an array, we use Heap Tree to find the max. 
            /// 
            /// Time Complexity : O(nlog(n))
            /// Space Complexity : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void HeapSort(double[] arr)
            {
                int n = arr.Length;
                int i;
                double tmp;
                // Build heap (rearrange array)
                for (i = (n / 2) - 1; i >= 0; i--)
                {
                    Heapify(arr, n, i);
                }

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
            private static void Heapify(double[] arr, int n, int i)
            {
                double tmp;
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
                    // Swap arr[i] with arr[largest]
                    tmp = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = tmp;
                    // Recursively heapify the affected sub-tree
                    Heapify(arr, n, largest);
                }
            }

            /// <summary>
            /// Sorts an array by counting every element.
            /// Also called "Count Sort" but dont confuse with "Counting Sort".
            /// 
            /// Time Complexity : O(n+k) where k = max - min
            /// Space Complexity : O(k)
            /// </summary>
            /// <param name="arr"></param>
            public static void PigeonHoleSort(int[] arr)
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

            /// <summary>
            ///  Sorts an array by calculating the position of every number
            ///  
            /// Time Complexity : O(n^2)
            /// Space Complexity : O(n)
            /// </summary>
            /// <param name="arr"></param>
            public static void CountingSort(double[] arr)
            {
                int n = arr.Length;
                double[] tmp = new double[n];
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

            /// <summary> 
            /// Independently discovered by Erhan Tezcan (July 2017).
            /// Its very similar to FlashSort but performs worse on Space Complexity.
            /// 
            /// Time Complexity : ?
            /// Space Complexity : O(n)
            /// </summary>
            public static void GoodSort(double[] arr)
            {
                GoodSortR(arr, 0, arr.Length - 1);
            }
            private static void GoodSortR(double[] arr, int l, int r)
            {
                int n = r - l + 1;
                // Find min and max while also checking if all numbers are the same.
                bool allNumbersSame = true;
                double min = arr[l];
                double max = arr[l];
                for (int i = l; i <= r; i++)
                {
                    if (arr[i] != arr[l]) allNumbersSame = false;
                    if (arr[i] < min) min = arr[i];
                    if (arr[i] > max) max = arr[i];
                }
                // If all numbers are same the array is sorted!
                if (allNumbersSame) return;

                // Calculate collisions
                int[] collisions = new int[n];
                for (int i = l; i <= r; i++)
                {
                    int pos = (int)Math.Floor((arr[i] - min) / (max - min) * ((double)n - 1));
                    collisions[pos]++;
                }
                // Calculate offsets
                int[] offsets = new int[n];
                int offset = 0;
                for (int i = 0; i < n; i++)
                {
                    if (collisions[i] == 0) offset--;
                    offsets[i] = offset;
                    if (collisions[i] > 1) offset += collisions[i] - 1;
                }
                // Calculate collisions offseted
                int[] collisionsOffseted = new int[n]; // All values are assumed initially 0
                for (int i = 0; i < n; i++)
                {
                    if (collisions[i] != 0)
                    {
                        collisionsOffseted[i + offsets[i]] = collisions[i];
                    }
                }
                // Edit the array, but clone collisionsOffseted first because it is needed later.
                int[] tmpCollisionsOffseted = new int[n];
                int maxPlacer = 0;
                collisionsOffseted.CopyTo(tmpCollisionsOffseted, 0);
                double[] newArr = new double[n];
                for (int i = l; i <= r; i++)
                {
                    int pos = (int)Math.Floor((arr[i] - min) / (max - min) * ((double)n - 1));
                    if (arr[i] != max)
                    {
                        newArr[pos + offsets[pos] + tmpCollisionsOffseted[pos + offsets[pos]] - 1] = arr[i];
                    }
                    else
                    {
                        newArr[pos - maxPlacer] = arr[i];
                        maxPlacer++;
                    }
                    tmpCollisionsOffseted[pos + offsets[pos]]--;
                }
                // Assign new array back
                for (int i = l; i <= r; i++)
                {
                    arr[i] = newArr[i - l];
                }
                // Recurse for collisions
                bool isCollecting = false;
                int from = 0;
                int to = 0;
                for (int i = 0; i < n; i++)
                {
                    if (collisionsOffseted[i] == 1)
                    {
                        if (isCollecting)
                        {
                            GoodSortR(arr, from + l, to + l);
                            isCollecting = false;
                        }
                        else
                        {
                            // do nothing
                        }
                    }
                    else
                    {
                        if (isCollecting)
                        {
                            to = i;
                        }
                        else
                        {
                            from = i;
                            isCollecting = true;
                        }
                    }
                }
            }

            // HATA VAR BURDAAAAAAAAAAAAAAAAAA
            /// <summary>
            /// Independently discovered by Erhan Tezcan (July 2017).
            /// It is a kind of Merge Sort but exploits the natural occurences of sorted data in the array.
            /// </summary>
            /// <param name="arr"></param>
            public static void NaturalMergeSort(double[] arr)
            {
                int n = arr.Length;
                int[] adders = new int[n]; // array to store adders
                double[] merger = new double[n]; // array for merging
                int adder = 1;
                int i, j, k, size;
                Queue<int> q = new Queue<int>(); // queue to calculate adders
                Stack<int> s = new Stack<int>(); // stores the start of sub-arrays that are ascending
                q.Enqueue(0); // starting from 0th element
                s.Push(0);
                while (q.Count > 0)
                {
                    i = q.Dequeue();
                    if (i < n)
                    {
                        if (i + adder >= n || arr[i] <= arr[i + adder]) // i+adder_cur>=n so that we can escape through the first condition
                        {
                            // Go to next guy
                            adders[i] = adder; // write adder
                            q.Enqueue(i + adder); // go to next guy
                        }
                        else
                        {
                            q.Enqueue(i); // Add current guy and next guy to the queue, increase adder.
                            q.Enqueue(i + adder); // this is the start of a new array
                            s.Push(i + adder); // record the start of the array
                            adder++; // increase adder
                        }
                    }
                }
                k = 0;
                // Take the top array and assign it to our merge target
                i = s.Pop();
                while (i < n)
                {
                    merger[k++] = arr[i];
                    i += adders[i];
                }

                while (s.Count > 0)
                {
                    // Assign merger to tmp
                    double[] tmp = new double[k];
                    for (i = 0; i < k; i++)
                    {
                        tmp[i] = merger[i];
                    }
                    // Merge tmp with the array from adders
                    i = s.Pop(); // for arr
                    j = 0; // for tmp    
                    size = k; // size for tmp            
                    k = 0; // for merger                
                           // Merge from both
                    while (j < size && i < n)
                    {
                        if (tmp[j] < arr[i])
                        {
                            merger[k] = tmp[j];
                            j++;
                        }
                        else
                        {
                            merger[k] = arr[i];
                            i += adders[i];
                        }
                        k++;
                    }
                    // Merge distinct
                    while (j < size)
                    {
                        merger[k] = tmp[j];
                        j++;
                        k++;
                    }
                    while (i+adders[i] < n)
                    {
                        merger[k] = arr[i];
                        i += adders[i];
                        k++;
                    }
                }

                // Copy the new array to original array
                for (i = 0; i < n; i++)
                {
                    arr[i] = merger[i];
                }

            }
             
            /// <summary>
            /// Independently discovered by Erhan Tezcan (May 2017). 
            /// Another name of this algorithm is Binary Quick-Sort. The numbers are looked at in binary notation,
            /// starting from the Most Significant Bit, the 1s are pushed to the left, and 0s are pushed to the right. 
            /// This happes recursively, and the array is sorted.
            /// </summary>
            /// <param name="arr"></param>
            public static void RadixExchangeSort(int[] arr)
            {
                // d is related to the bit count. If the array is made of 3-bit numbers, initial d will be 2^(3-1) = Math.Pow(2,2)
                RadixEchangeSortPartition(arr, 0, arr.Length - 1, (int)Math.Pow(2, 31));
            }
            private static void RadixEchangeSortPartition(int[] arr, int l, int r, int d)
            {
                if (d >= 0 && r > l)
                {
                    int init_l = l;
                    int init_r = r;
                    int tmp;
                    int swapCount = 0;
                    while (l < r)
                    {
                        // If bit is 0 keep going
                        while ((l < r) && ((arr[l] & d) == 0))
                        {
                            l++;
                        }
                        // If bit is 1 keep going
                        while ((r > l) && ((arr[r] & d) == d))
                        {
                            r--;
                        }
                        tmp = arr[l];
                        arr[l] = arr[r];
                        arr[r] = tmp;
                        swapCount++;
                    }
                    // If something like 00000 or 11111 is on the row, skip that row.
                    if (swapCount == 1)
                    {
                        RadixEchangeSortPartition(arr, init_l, init_r, d >> 1);
                    }
                    else
                    {
                        RadixEchangeSortPartition(arr, init_l, l - 1, d >> 1);
                        RadixEchangeSortPartition(arr, l, init_r, d >> 1);
                    }
                }


            }

            /// <summary>
            /// Sorts an integer array by looking at their digits. Starting from the rightmost digit, the numbers are sorted.
            /// Afterwards, other digits are also looked at, and algorithm stops when all digits are looked. A condition is that first
            /// we have to find how many digits the maximum number has. This is base 10 implementation.
            /// 
            /// Time Complexity : O(log_b(k)*(n+b)), on avarage worse than normal comparison algorithms for large k.
            /// Auxillary Space : Uses a lot of space because additional space is used in every step. RadixEchangeSort overcomes this problem.
            /// </summary>
            /// <param name="arr"></param>
            public static void StraightRadixSort(int[] arr)
            {
                // First find max
                int max = (int)arr[Searching.FindMax(Miscellaneous.IntToDouble(arr))];

                // Do RadixCountSort for every digit.
                // Instead of passing the digit number, pass exp which is 10^(digitNo).
                for (int exp = 1; max / exp > 0; exp *= 10)
                {
                    RadixCountSort(arr, exp);
                }
            }
            private static void RadixCountSort(int[] arr, int exp)
            {
                int n = arr.Length;
                int[] output = new int[n];
                int[] count = new int[10]; // initally all 0s
                for (int i = 0; i < n; i++)
                {
                    count[(arr[i] / exp) % 10]++;
                }

                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                    count[(arr[i] / exp) % 10]--;
                }

                for (int i = 0; i < n; i++)
                {
                    arr[i] = output[i];
                }
            }

            /// <summary>
            /// Sorts an array using pivots. It is a recursive algorithm and uses Divide and Conquer approach.
            /// 
            /// Time Complexity : O(nlog(n))
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void QuickSort(double[] arr)
            {
                QuickSortR(arr, 0, arr.Length - 1);
            }
            private static void QuickSortR(double[] arr, int l, int r)
            {
                if (l < r)
                {
                    // arr[pi] which is the pivot will be in the right place after this partition.
                    int pi = QuickSortPartition(arr, l, r);
                    // Recursively sort the right and left side of the pivot.
                    QuickSortR(arr, l, pi - 1); // left side
                    QuickSortR(arr, pi + 1, r); // right side
                }
            }
            private static int QuickSortPartition(double[] arr, int l, int r)
            {
                // this function places the pivot in its right place and pushes other elements to its right or left according to their vaule.
                double pivot = arr[r];
                int i = l - 1; // index of smaller element
                for (int j = l; j < r; j++)
                {
                    // If current element is smaller than or equal to the pivot
                    if (arr[j] <= pivot)
                    {
                        i++;
                        // swap arr[i] and arr[j]
                        double tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;

                    }
                }

                // swap arr[i+1] and arr[high]
                double temp = arr[i + 1];
                arr[i + 1] = arr[r];
                arr[r] = temp;
                return i + 1;
            }

            /// <summary>
            /// 3-way QuickSort handles the problem of recurring data, which is reduntant for a sorting algorithm. 
            /// Uses Dutch National Flag algorithm.
            /// 
            /// Time Complexity : O(nlog(n))
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void Quick3Sort(double[] arr)
            {
                Quick3SortR(arr, 0, arr.Length - 1);
            }
            private static void Quick3SortR(double[] arr, int l, int r)
            {
                if (l < r)
                {
                    int i = l - 1, j = r;
                    // arr[pi] which is the pivot will be in the right place after this partition.
                    Quick3SortPartition(arr, l, r, ref i, ref j);
                    // Recursively sort the right and left side of the pivot.
                    Quick3SortR(arr, l, j); // left side
                    Quick3SortR(arr, i, r); // right side
                }
            }
            private static void Quick3SortPartition(double[] arr, int l, int r, ref int i, ref int j)
            {
                i = l - 1;
                j = r;
                int p = l - 1, q = r;
                double v = arr[r]; // last element

                while (true)
                {
                    // From left, find the first element greater than or equal to v.
                    // This loop will definetly terminate as v is the last element
                    while (arr[++i] < v) ;

                    // From right, find the first element smaller than or equal to v.
                    while (v < arr[--j])
                    {
                        if (j == l)
                        {
                            break;
                        }
                    }

                    // If i and j cross, we are done
                    if (i >= j)
                    {
                        break;
                    }

                    // Swapping smaller with bigger (usual partition)
                    Arrays.Miscellaneous.Swap(arr, i, j);

                    // Move all same left occurence of pivot to the beginning of array and keep count using p
                    if (arr[i] == v)
                    {
                        p++;
                        Arrays.Miscellaneous.Swap(arr, p, i);
                    }

                    // Move all same right occurences of pivot to the end of array and keep count using p.
                    if (arr[j] == v)
                    {
                        q--;
                        Arrays.Miscellaneous.Swap(arr, j, q);
                    }
                }

                // Move pivot to its correct index
                Arrays.Miscellaneous.Swap(arr, i, r);

                // Move all left same occurences from beginning to adjacent to arr[i]
                j = i - 1;
                for (int k = l; k < p; k++, j--)
                {
                    Arrays.Miscellaneous.Swap(arr, k, j);
                }
                i = i + 1;
                // Move all right same occurences from end to adjacent to arr[i]
                for (int k = r - 1; k > q; k--, i++)
                {
                    Arrays.Miscellaneous.Swap(arr, i, k);
                }
            }

            /// <summary>
            /// Sorts an array using merge algorithm after dividing the array into many pieces. It is a recursive algorithm and uses Divide and Conquer approach.
            /// 
            /// Time Complexity : O(nlog(n))
            /// Auxillary Space : O(n)
            /// </summary>
            /// <param name="arr"></param>
            public static void MergeSort(double[] arr)
            {
                MergeSortR(arr, 0, arr.Length - 1);
            }
            private static void MergeSortR(double[] arr, int l, int r)
            {
                if (l < r)
                {
                    // Same as (l+r)/2 but avoid overflow for large l and r.
                    int m = l + (r - l) / 2;

                    MergeSortR(arr, l, m); // left half
                    MergeSortR(arr, m + 1, r); // right half

                    MergeSortMerge(arr, l, m, r);
                }

            }
            private static void MergeSortMerge(double[] arr, int l, int m, int r)
            {
                int i, j, k;
                int n1 = m - l + 1;
                int n2 = r - m;

                double[] left = new double[n1];
                double[] right = new double[n2];

                for (i = 0; i < n1; i++)
                {
                    left[i] = arr[l + i];
                }
                for (j = 0; j < n2; j++)
                {
                    right[j] = arr[m + 1 + j];
                }

                i = 0;
                j = 0;
                k = l;
                while (i < n1 && j < n2)
                {
                    if (left[i] <= right[j])
                    {
                        arr[k] = left[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = right[j];
                        j++;
                    }
                    k++;
                }

                // Copy the remaining elements of left[] if there are any
                while (i < n1)
                {
                    arr[k] = left[i];
                    i++;
                    k++;
                }
                // Copy the remaining elements of right[] if there are any
                while (j < n2)
                {
                    arr[k] = right[j];
                    j++;
                    k++;
                }
            }

            /// <summary>
            /// Unlike normal merge sort which splits the arrays into 2, 3-way Merge sort splits them into 3. 
            /// Even though it seems this should be faster, because more comparisons are done it is slower than normal Merge Sort.
            /// 
            /// Time Complexity : O(nlog(n))
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void Merge3Sort(double[] arr)
            {
                Merge3SortR(arr, 0, arr.Length - 1);

            }
            private static void Merge3SortR(double[] arr, int l, int r)
            {
                if (l < r)
                {
                    int mid1 = l + (r - l) / 3;
                    int mid2 = mid1 + (r - l) / 3;

                    Merge3SortR(arr, l, mid1); // left third
                    Merge3SortR(arr, mid1 + 1, mid2); // middle third
                    Merge3SortR(arr, mid2 + 1, r); // right third

                    Merge3SortMerge(arr, l, mid1, mid2, r);
                }
            }
            private static void Merge3SortMerge(double[] arr, int l, int mid1, int mid2, int r)
            {
                int i, j, k, a;
                int n1 = mid1 - l + 1;
                int n2 = mid2 - mid1;
                int n3 = r - mid2;

                double[] left = new double[n1];
                double[] middle = new double[n2];
                double[] right = new double[n3];

                for (i = 0; i < n1; i++)
                {
                    left[i] = arr[l + i];
                }
                for (j = 0; j < n2; j++)
                {
                    middle[j] = arr[mid1 + 1 + j];
                }
                for (k = 0; k < n3; k++)
                {
                    right[k] = arr[mid2 + 1 + k];
                }

                // Merge 3 arrays (left, middle, right)
                i = 0; // left iterator
                j = 0; // middle iterator
                k = 0; // right iterator
                a = l; // array iterator

                // Left, Middle and Right all have values
                while (i < n1 && j < n2 && k < n3)
                {
                    if (left[i] <= middle[j])
                    {
                        if (left[i] <= right[k])
                        {
                            arr[a++] = left[i++];
                        }
                        else
                        {
                            arr[a++] = right[k++];
                        }
                    }
                    else
                    {
                        if (middle[j] <= right[k])
                        {
                            arr[a++] = middle[j++];
                        }
                        else
                        {
                            arr[a++] = right[k++];
                        }
                    }
                }

                // Left and Middle have remaining values
                while (i < n1 && j < n2)
                {
                    if (left[i] <= middle[j])
                    {
                        arr[a++] = left[i++];
                    }
                    else
                    {
                        arr[a++] = middle[j++];
                    }

                }
                // Middle and Right have remaining values
                while (j < n2 && k < n3)
                {
                    if (middle[j] <= right[k])
                    {
                        arr[a++] = middle[j++];
                    }
                    else
                    {
                        arr[a++] = right[k++];

                    }

                }
                // Left and Right have remaining values
                while (i < n1 && k < n3)
                {
                    if (left[i] <= right[k])
                    {
                        arr[a++] = left[i++];
                    }
                    else
                    {
                        arr[a++] = right[k++];
                    }
                }

                // Copy the remaining elements of left[] if there are any
                while (i < n1)
                {
                    arr[a++] = left[i++];
                }
                // Copy the remaining elements of middle[] if there are any
                while (j < n2)
                {
                    arr[a++] = middle[j++];
                }
                // Copy the remaining elements of right[] if there are any
                while (k < n3)
                {
                    arr[a++] = right[k++];
                }

            }

            /// <summary>
            /// Similar to how we sort playing cards in our hands, insertion sort works by sorting the left handside step by step.
            /// 
            /// Time Complexity : O(n^2)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void InsertionSort(double[] arr)
            {
                int n = arr.Length;
                for (int i = 1; i < n; ++i)
                {
                    double key = arr[i];
                    int j = i - 1;

                    // Move element of arr[0...i-1], that are greater than key, one position ahead of their current position
                    while (j >= 0 && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j = j - 1;
                    }
                    arr[j + 1] = key;
                }
            }

            /// <summary>
            /// Shell Sort is a variation of Insertion Sort. Overcomes the problem of moving only one element at a time in Insertion Sort
            /// by moving elements with much bigger motions (gap).
            /// 
            /// Time Complexity : O(n^2)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void ShellSort(double[] arr)
            {
                int n = arr.Length;
                // Start with a big gap, then reduce the gap.
                for (int gap = n / 2; gap > 0; gap /= 2)
                {
                    // Do a gapped insertion for this gap size. The first gao element a[0...gap-1] are already in gapped order.
                    // Keep adding one more element until the entire array is gap sorted.
                    for (int i = gap; i < n; i += 1)
                    {
                        // Save a[i] in temp to make a hole at position i.
                        double temp = arr[i];
                        // shift earlier gap-sorted elements up until correct location for a[i] is found.
                        int j;
                        for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        {
                            arr[j] = arr[j - gap];
                        }
                        // Put original a[i] to its new place j.
                        arr[j] = temp;
                    }
                }

            }

            /// <summary>
            /// Possibly worst soring algorithm out there, randomly shuffles the array and checks if its sorted.
            /// 
            /// Time Complexity : O(n!)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void BogoSort(double[] arr)
            {
                while (!IsSorted(arr))
                {
                    Arrays.Miscellaneous.FisherYatesShuffle(arr);
                }
            }

            /// <summary>
            /// Also known as Cocktail Shaker Sort, it is just a bi-directional Bubble Sort.
            /// 
            /// Time Complexity : O(n^2)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void ShakerSort(double[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n / 2; i++)
                {
                    bool swapped = false;
                    for (int j = i; j < n - i - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            Arrays.Miscellaneous.Swap(arr, j, j + 1);
                            swapped = true;
                        }
                    }
                    for (int j = n - 2 - i; j > i; j--)
                    {
                        if (arr[j] > arr[j - 1])
                        {
                            Arrays.Miscellaneous.Swap(arr, j, j - 1);
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
            }

            /// <summary>
            /// Main focus of this algorithm is to make minimum amount of memory writes. 
            /// It should be used when memory write or swap operations are costly.
            /// 
            /// Time Complexity : O(n^2)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void CycleSort(double[] arr)
            {
                int n = arr.Length;
                for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
                {
                    // initialize item as starting point
                    double item = arr[cycle_start];

                    // find position where we put the item
                    int pos = cycle_start;
                    for (int i = cycle_start + 1; i < n; i++)
                    {
                        if (arr[i] < item)
                        {
                            pos++;
                        }
                    }

                    // If item is already in correct position
                    if (pos == cycle_start)
                    {
                        continue; // skips the rest of this iteration
                    }

                    // ignore all duplicates
                    while (item == arr[pos])
                    {
                        pos += 1;
                    }

                    // put the item to the right position
                    if (pos != cycle_start)
                    {
                        double tmp = item;
                        item = arr[pos];
                        arr[pos] = tmp;
                    }

                    // rotate rest of the cycle
                    while (pos != cycle_start)
                    {
                        pos = cycle_start;
                        // find position where we put element
                        for (int i = cycle_start + 1; i < n; i++)
                        {
                            if (arr[i] < item)
                            {
                                pos += 1;
                            }
                        }

                        // ignore duplicates
                        while (item == arr[pos])
                        {
                            pos += 1;
                        }

                        // put the item to its right position
                        if (item != arr[pos])
                        {
                            double tmp = item;
                            item = arr[pos];
                            arr[pos] = tmp;
                        }
                    }
                }
            }

            // HATA VAR BURADAAAAAAAAAAAAAAAAAAA
            /// <summary>
            /// Bitonic Sort is like merge sort, but it is very suitable for multi-threading. 
            /// As in complexity, it is still worse than Merge Sort because it has more comparisons.
            /// 
            /// Time Complexity : O(nlog(n))
            /// </summary>
            /// <param name="arr"></param>
            public static void BitonicSort(double[] arr)
            {
                // last parameter is dir, 1 means ASCENDING SORT, 0 means DESCENDING SORT
                BitonicSortR(arr, 0, arr.Length - 1, 1);
            }
            private static void BitonicSortR(double[] arr, int low, int cnt, int dir)
            {
                if (cnt > 1)
                {
                    int k = cnt / 2;

                    // Sort in ascending order (dir = 1)
                    BitonicSortR(arr, low, k, 1);

                    // Sort in descending order (dir = 0)
                    BitonicSortR(arr, low + k, k, 0);

                    // Merging
                    BitonicSortMerge(arr, low, cnt, dir);
                }
            }
            private static void BitonicSortCompareAndSwap(double[] arr, int i, int j, int dir)
            {
                // this swapping looks if the values agree with the direction, and depending on that they are swapped
                if ((arr[i] > arr[j] && dir == 1) || (arr[i] < arr[j] && dir == 0))
                {
                    Miscellaneous.Swap(arr, i, j);
                }
            }
            private static void BitonicSortMerge(double[] arr, int low, int cnt, int dir)
            {
                if (cnt > 1)
                {
                    int k = cnt / 2;
                    for (int i = low; i < low + k; i++)
                    {
                        BitonicSortCompareAndSwap(arr, i, i + k, dir);
                    }
                    BitonicSortMerge(arr, low, k, dir);
                    BitonicSortMerge(arr, low + k, k, dir);
                }
            }

            /// <summary>
            /// The algorithm gets its name from "A garden gnome sorting his flower pots."
            /// It has only 1 while loop, but because the index can both increment and decrement it is not linear.
            /// 
            /// Time Complexity : O(n^2)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void GnomeSort(double[] arr)
            {
                int i = 0;
                int n = arr.Length;
                while (i < n)
                {
                    // if we are at the start go one step forward
                    if (i == 0)
                    {
                        i++;
                    }
                    // if pots are ordered well go one step forward
                    if (arr[i] >= arr[i - 1])
                    {
                        i++;
                    }
                    else
                    // if pots are ordered wrong, swap them and go one step back
                    {
                        Miscellaneous.Swap(arr, i, i - 1);
                        i--;
                    }
                }
            }

            /// <summary>
            /// The algorithm gets its name from the way it works, which is flipping. 
            /// As flipping is common when making a pancake, this is what it is called.
            /// 
            /// Time Complexity : O(n^2) becuase there are O(n) flip operations.
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            public static void PancakeSort(double[] arr)
            {
                int n = arr.Length;
                // Start from the complete array one by one and reduce current size by one
                for (int curr_size = n; curr_size > 1; --curr_size)
                {
                    // Fin index of the maximum element in arr[0..curr_size-1]
                    int mi = PancakeSortFindMax(arr, curr_size);
                    // Move the maximum element to end of current array if its not already at the end
                    if (mi != curr_size - 1)
                    {
                        // To move at the end, first move maximum number to beginning
                        PancakeSortFlip(arr, mi); // Flip
                        // Now move the maximum number to the end by reversing current array
                        PancakeSortFlip(arr, curr_size - 1); // Flip
                    }
                }
            }
            private static void PancakeSortFlip(double[] arr, int i)
            {
                // This function reverses arr[0...i] to arr[i..0]
                double tmp;
                int start = 0;
                while (start < i)
                {
                    tmp = arr[start];
                    arr[start] = arr[i];
                    arr[i] = tmp;
                    start++;
                    i--;
                }
            }
            private static int PancakeSortFindMax(double[] arr, int n)
            {
                int mi, i;
                for (mi = 0, i = 0; i < n; ++i)
                {
                    if (arr[i] > arr[mi])
                    {
                        mi = i;
                    }
                }
                return mi;
            }

            /// <summary>
            /// TimSort is a pretty new algorithm (2002) and it is fast. Used by Java JDK 7.0, Phyton and Android,
            /// it is basically Insertion Sort and Merge Sort together, where both are used when they are advantageous to use.
            /// </summary>
            /// <param name="arr"></param>
            public static void TimSort(double[] arr)
            {
                int RUN = 32; // insertion sort will be done to arrays of size 32
                int n = arr.Length;
                // sort individual sub-arrays of size RUN
                for (int i = 0; i < n; i += RUN)
                {
                    TimeSortInsertionSort(arr, i, Math.Min((i + RUN - 1), (n - 1)));
                }

                // start merging
                for (int size = RUN; size < n; size = 2 * size)
                {
                    // pick starting point of left sub array.
                    // Merge arr[left..left+size-1] with arr[left+size..left+2*size-1]
                    for (int left = 0; left < n; left += 2 * size)
                    {
                        // find ending point of left sub array, and +1 of that will be the start of the right array
                        int mid = left + size - 1;
                        int right = Math.Min((left + 2 * size - 1), (n - 1)); // after each merge, increase left by 2*size

                        // merging
                        TimSortMerge(arr, left, mid, right);
                    }
                }
            }
            private static void TimeSortInsertionSort(double[] arr, int l, int r)
            {
                // basic insertion sort which sorts the sub-array specified by 2 parameters "left" and "right", inclusive)
                for (int i = l + 1; i <= r; i++)
                {
                    double temp = arr[i];
                    int j = i - 1;
                    while (j >= l && arr[j] > temp)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = temp;
                }
            }
            private static void TimSortMerge(double[] arr, int l, int m, int r)
            {
                // basic merge sort which merges two sorted arrays specified by 3 parameters, "left", "middle" and "right".
                int len1 = m - l + 1;
                int len2 = r - m;
                double[] left = new double[len1];
                double[] right = new double[len2];
                for (int li = 0; li < len1; li++)
                {
                    left[li] = arr[l + li];
                }
                for (int ri = 0; ri < len2; ri++)
                {
                    right[ri] = arr[m + 1 + ri];
                }

                int i = 0, j = 0, k = l;
                while (i < len1 && j < len2)
                {
                    if (left[i] <= right[j])
                    {
                        arr[k] = left[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = right[j];
                        j++;
                    }
                    k++;
                }

                while (i < len1)
                {
                    arr[k] = left[i];
                    k++;
                    i++;
                }
                while (j < len2)
                {
                    arr[k] = right[j];
                    k++;
                    j++;
                }
            }

            /// <summary>
            /// Returns a boolean value indicating if the array is sorted or not.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static bool IsSorted(double[] arr)
            {
                int n = arr.Length;
                // It can either be ascending or descending
                // But first, if it is too small it is sorted
                if (arr.Length <= 2)
                {
                    return true;
                }
                // Difference between first and last elements will tell a lot about the array if its sorted
                double diff = arr[n - 1] - arr[0];
                int i = 1;
                if (diff == 0) // All elements should be equal
                    while (i < n && arr[i] == arr[i - 1]) i++;
                else
                if (diff > 0) // Elements should be in ascending or equal order
                    while (i < n && arr[i] >= arr[i - 1]) i++;
                else
                    // Elements should be in descending or equal order
                    while (i < n && arr[i] <= arr[i - 1]) i++;

                if (i == n) return true; else return false;
            }
        }
       
        /// <summary>
        /// Various search algorithms for searching a number in an array and retrieving its position or searching for a specific thing in an array (such as Max).
        /// </summary>
        public class Searching
        {
            /// <summary>
            /// Finds the maximum value in an array between the specified positions.
            /// </summary>
            /// <param name="arr">Array of type Double</param>
            /// <param name="from">The starting position of values in the array to be considered</param>
            /// <param name="to">The ending position of values in the array to be considered</param>
            /// <returns>The maximum value in the array. If the from and to indexes are given badly, it will return Double.MinVal</returns>
            public static int FindMax(double[] arr, int from, int to)
            {
                int maxpos = from, n = arr.Length;
                if (from >= 0 && to < n)
                {
                    for (int i = from; i <= to; i++)
                        if (arr[i] > arr[maxpos])
                            maxpos = i;
                    return maxpos;
                }
                else
                {
                    return -1;
                }
            }

            /// <summary>
            /// Finds the minimum value in an array between the specified positions.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <returns></returns>
            public static int FindMin(double[] arr, int from, int to)
            {
                int minpos = from, n = arr.Length;
                if (from >= 0 && to < n)
                {
                    for (int i = from; i < to; i++)
                        if (arr[i] < arr[minpos])
                            minpos = i;
                    return minpos;
                }
                else
                {
                    return -1;
                }
            }

            /// <summary>
            /// Finds the minimum value in an array.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int FindMin(double[] arr)
            {
                int minpos = 0, n = arr.Length;
                for (int i = 1; i < n; i++)
                    if (arr[i] < arr[minpos])
                        minpos = i;
                return minpos;
            }

            /// <summary>
            /// Find the maximum value in an array.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int FindMax(double[] arr)
            {
                int maxpos = 0, n = arr.Length;
                for (int i = 1; i < n; i++)
                    if (arr[i] > arr[maxpos])
                        maxpos = i;
                return maxpos;
            }

            /// <summary>
            /// Finds the median value in the array.
            /// Median value is the value that would be in the middle of the array if it were to be sorted.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int FindMedian(double[] arr)
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
                return a;
            }

            /// <summary>
            /// Finds the avarage value of the elements in the array.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static double FindAvarage(double[] arr)
            {
                int n = arr.Length;
                double sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += arr[i] / (double)n; // works a bit slower than dividing at the end, but it is safer
                }
                return sum;
            }

            /// <summary>
            /// Returns a boolean value indicating if the array has a recurring element or not.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static bool HasRecurrence(double[] arr)
            {
                int n = arr.Length, control, k = 0;
                double[] b = new double[n];
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

            /// <summary>
            /// Finds the most recurring element in an array.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static double FindMostRecurringElement(double[] arr)
            {
                int n = arr.Length;
                int k = 0, control;
                double[] kinds = new double[n];
                double[] counts = new double[n];
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
                return kinds[LinearSearch(counts, counts[FindMax(counts)])];
            }

            /// <summary>
            /// Uses Binary Search algorithm to find an element in a sorted array.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int BinarySearch(double[] arr, double x)
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

            /// <summary>
            /// Unlike Binary Search which splits in 2, Ternary Search splits in 3. However, as calculations show it, it performs
            /// worse than Binary Search, because the number of comparisons are higher for Ternary Search.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int TernarySearch(double[] arr, double x)
            {
                return TernarySearchR(arr, 0, arr.Length - 1, x);
            }
            private static int TernarySearchR(double[] arr, int l, int r, double x)
            {
                if (r >= l)
                {
                    int mid1 = l + (r - l) / 3;
                    int mid2 = mid1 + (r - l) / 3;

                    // If x is present at mid1
                    if (arr[mid1] == x) return mid1;

                    // If x is present at mid2
                    if (arr[mid2] == x) return mid2;

                    // x might be in left one-third
                    if (arr[mid1] > x) return TernarySearchR(arr, l, mid1 - 1, x);

                    // x might be in right one-third
                    if (arr[mid2] < x) return TernarySearchR(arr, mid2 + 1, r, x);

                    // x might be in middle one-third
                    return TernarySearchR(arr, mid1 + 1, mid2 - 1, x);
                }
                // x is not in the array
                return -1;
            }

            /// <summary>
            /// Linearly searches an element in an array.
            /// 
            /// Time Complexity : O(n)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int LinearSearch(double[] arr, double x)
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

            /// <summary>
            /// Independently discovered by Erhan Tezcan (July 2017).
            /// Uses a probing function to search the element in a sorted array.
            /// 
            /// Time Complexity : O(log(log(N))) but can be up to O(N)
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int InterpolationSearch(double[] arr, double x)
            {
                int l = 0, r = arr.Length - 1;
                while (l <= r && x >= arr[l] && x <= arr[r])
                {
                    int pos = (int)(l + (x - arr[l]) / (arr[r] - arr[l]) * (r - l));
                    if (arr[pos] == x)
                    {
                        return pos;
                    }
                    if (arr[pos] < x)
                    {
                        l = pos + 1;
                    }
                    else
                    {
                        r = pos - 1;
                    }
                }
                return -1;
            }

            /// <summary>
            /// Similar to binary search, it is used for Sorted Arrays.
            /// Jumping happens so that we can check fewer elements than linear search by jumping ahead a few steps.
            /// So we search between blocks with block size M. When we have "x is between arr[km] and arr[(k+1)m]" we do linear search.
            /// 
            /// Time Complexity : O(sqrt(n))
            /// Auxillary Space : O(1)
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int JumpSearch(double[] arr, double x)
            {
                int n = arr.Length;

                // Finding block size.
                int step = (int)Math.Floor(Math.Sqrt(n));

                // Finding the block where element is present if it is.
                int prev = 0;
                while (arr[Math.Min(step, n) - 1] < x)
                {
                    prev = step;
                    step += (int)Math.Floor(Math.Sqrt(n));
                    if (prev >= n)
                    {
                        return -1;
                    }
                }

                // Doing a linear search for in the block
                while (arr[prev] < x)
                {
                    prev++;
                    // If element is still not found
                    if (prev == Math.Min(step, n))
                    {
                        return -1;
                    }
                }
                // If element is found
                if (arr[prev] == x)
                {
                    return prev;
                }

                return -1;
            }

            /// <summary>
            /// It uses Fibonacci Numbers, here is how: 
            /// Find the smallest Fibonacci Number (m'th fibonacci number) that is greater than or equal to length of array.
            /// Use (m-2)th fibonacci number as index if valid, and depending on the value of that element compared to the one we search,
            /// recur either right or left side.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="x"></param>
            /// <returns></returns>
            public static int FibonacciSearch(double[] arr, double x)
            {
                int n = arr.Length;

                int fibMMm2 = 0; // m-2 element
                int fibMMm1 = 1; // m-1 element
                int fibM = fibMMm2 + fibMMm1; // m element
                while (fibM < n)
                {
                    fibMMm2 = fibMMm1;
                    fibMMm1 = fibM;
                    fibM = fibMMm2 + fibMMm1;
                }

                int offset = -1;
                while (fibM > 1)
                {
                    int i = Math.Min(offset + fibMMm2, n - 1);
                    if (arr[i] < x)
                    {
                        // recur for 
                        fibM = fibMMm1;
                        fibMMm1 = fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                        offset = i;
                    }
                    else if (arr[i] > x)
                    {
                        fibM = fibMMm2;
                        fibMMm1 = fibMMm1 - fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                    }
                    else
                    {
                        return i;
                    }
                }

                // comparing the last element
                if (fibMMm1 != 0 && arr[offset + 1] == x) return offset + 1;

                return -1;
            }
            
        }

        /// <summary>
        /// Various algorithms for various purposes.
        /// </summary>
        public class Miscellaneous
        {
            /// <summary>
            /// Merges two sorted arrays into a single sorted array.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static double[] MergeArrays(double[] a, double[] b)
            {

                int n = a.Length, m = b.Length;
                int i = 0, j = 0, k = -1;
                double[] c = new double[n + m];

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

            /// <summary>
            ///  Eliminates recurring elements by only letting the 1st recurrence stay if it recurs afterwards.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static double[] EliminateRecurrence(double[] arr)
            {
                int control, k = 0, n = arr.Length;
                double[] b = new double[n];
                for (int i = 0; i < n; i++)
                {
                    control = Arrays.Searching.LinearSearch(b, arr[i]);
                    if (control == -1)
                    {
                        b[k] = arr[i];
                        k++;
                    }
                }
                double[] c = new double[k];
                for (int i = 0; i < k; i++)
                {
                    c[i] = b[i];
                }
                return c;
            }

            /// <summary>
            /// Eliminates consecutive recurrences.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static double[] EliminatePlateau(double[] arr)
            {
                double x = -1;
                int k = 0, n = arr.Length;
                double[] b = new double[n];
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] != x)
                    {
                        x = arr[i];
                        b[k] = x;
                        k++;
                    }
                }
                double[] c = new double[k];
                for (int i = 0; i < k; i++)
                {
                    c[i] = b[i];
                }
                return c;
            }

            /// <summary>
            /// Shuffles elements in an array by randomly picking new indexes for each element.
            /// </summary>
            /// <param name="arr"></param>
            public static void ShuffleElements(double[] arr)
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
                    Swap(arr, j, shuffler[j]);
                }
            }

            /// <summary>
            /// Shuffle an array using Fisher-Yates Shuffle Algorithm.
            /// </summary>
            /// <param name="arr"></param>
            public static void FisherYatesShuffle(double[] arr)
            {
                Random r = new Random();
                int n = arr.Length;
                for (int k = 0; k < n; k++)
                {
                    int j = r.Next(k, n - 1);
                    Arrays.Miscellaneous.Swap(arr, k, j);
                }
            }

            /// <summary>
            /// Rotates the array to the right, placing the last element to the first position.
            /// </summary>
            /// <param name="arr"></param>
            public static void RotateRight(double[] arr)
            {
                int n = arr.Length;
                double lift, put;
                lift = arr[n - 1];
                for (int i = 0; i < n - 1; i++)
                {
                    put = lift;
                    lift = arr[i];
                    arr[i] = put;
                }
                arr[n - 1] = lift;
            }

            /// <summary>
            /// Rotates the array to the left, placing the first element to the last position.
            /// </summary>
            /// <param name="arr"></param>
            public static void RotateLeft(double[] arr)
            {
                int n = arr.Length;
                double lift, put;
                lift = arr[0];
                for (int i = n - 1; i > 0; i--)
                {
                    put = lift;
                    lift = arr[i];
                    arr[i] = put;
                }
                arr[0] = lift;
            }

            /// <summary>
            /// Rotates the sub-array which is specified by its starting and ending positions, to the right.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="from"></param>
            /// <param name="to"></param>
            public static void RotateRight(double[] arr, int from, int to)
            {
                double lift, put;
                lift = arr[to];
                for (int i = from; i < to; i++)
                {
                    put = lift;
                    lift = arr[i];
                    arr[i] = put;
                }
                arr[to] = lift;
            }

            /// <summary>
            /// Rotates the sub-array which is specified by its starting and ending positions, to the left.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="from"></param>
            /// <param name="to"></param>
            public static void RotateLeft(double[] arr, int from, int to)
            {
                double lift, put;
                lift = arr[from];
                for (int i = to; i > from; i--)
                {
                    put = lift;
                    lift = arr[i];
                    arr[i] = put;
                }
                arr[from] = lift;
            }

            /// <summary>
            /// Convert a double array to integer (Int32) array. 
            /// Expect data loss if the double array had numbers other than whole numbers.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int[] DoubleToInt(double[] arr)
            {
                int[] newarr = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    newarr[i] = (int)arr[i];
                }
                return newarr;
            }

            /// <summary>
            /// Convert an integer (Int32) array to double array. 
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static double[] IntToDouble(int[] arr)
            {
                double[] newarr = new double[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    newarr[i] = arr[i];
                }
                return newarr;
            }

            /// <summary>
            /// Some kind of convertion from double to integer.
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static int[] DoubleToIntWithInterpolation(double[] arr)
            {
                double max = arr[0];
                double min = arr[0];
                int n = arr.Length;
                int[] newarr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    newarr[i] = (int)(((arr[i] - min) * (n - 1) / (max - min)) + arr[i] * min);
                }
                return newarr;
            }

            /// <summary>
            /// Swap the positions of 2 values in the array.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="i"></param>
            /// <param name="j"></param>
            public static void Swap(double[] arr, int i, int j)
            {
                double tmp;
                tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }

            /// <summary>
            /// Swap the positiions of 2 values in the array.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="i"></param>
            /// <param name="j"></param>
            public static void SwapXor(int[] arr, int i, int j)
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[j] ^ arr[i];
                arr[i] = arr[i] ^ arr[j];
            }

            /// <summary>
            /// Independently discovered by Erhan Tezcan (December 2016). Swap the positions of 2 values in the array.
            /// How this works is:
            /// A, B
            /// A=A+B-(B=A), right after A+B, B=A and A+B-B becomes A+B-A, so A=B.
            /// There is a risk of integer overflow because of addition when using large numbers.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="i"></param>
            /// <param name="j"></param>
            public static void SwapOneLine(double[] arr, int i, int j)
            {
                arr[i] += arr[j] - (arr[j] = arr[i]);
            }
        }

        /// <summary>
        /// Basic functions to view the content of arrays.
        /// </summary>
        public class Printing
        {
            /// <summary>
            /// Returns a string to show the content of the array
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static string ShowElements(double[] arr)
            {
                string ans = "";
                foreach (double d in arr)
                {
                    ans += String.Format("{0:0.####}", d) + " ";
                }
                return ans;
            }

            /// <summary>
            /// Returns a string to show the content of the array
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public static string ShowElements(int[] arr)
            {
                string ans = String.Join(" ", arr);
                return ans;
            }
        }

        /// <summary>
        /// Algorithms for generating random array of numbers.
        /// </summary>
        public class Generating
        {
            private static Random r = new Random();

            /// <summary>
            /// Generates a sorted ascending array
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <param name="adder"></param>
            /// <returns></returns>
            public static double[] SortedAscendingArray(int n, double max, double adder)
            {
                double[] arr = new double[n];
                arr[n - 1] = r.NextDouble() * max + 1;
                for (int i = n - 2; i >= 0; i--)
                {
                    arr[i] = arr[i + 1] - r.NextDouble() * adder;
                }
                return arr;
            }

            /// <summary>
            /// Generates a sorted descending array
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <param name="adder"></param>
            /// <returns></returns>
            public static double[] SortedDescendingArray(int n, double max, double adder)
            {
                double[] arr = new double[n];
                arr[0] = r.NextDouble() * max + 1;
                for (int i = 1; i < n; i++)
                {
                    arr[i] = arr[i - 1] - r.NextDouble() * adder + 1;
                }
                return arr;
            }

            /// <summary>
            /// Generates a completely random array
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <param name="adder"></param>
            /// <returns></returns>
            public static double[] RandomArray(int n, double max)
            {
                double[] arr = new double[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = r.NextDouble() * max;
                }
                return arr;
            }

            /// <summary>
            /// Generates a random array with no recurrences
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <param name="adder"></param>
            /// <returns></returns>
            public static double[] RandomNoRecurrenceArray(int n, double max, double adder)
            {
                double[] arr = new double[n];
                double rdm_max, coefficient;
                int rdm_pos, i = 0;
                rdm_max = r.NextDouble() * max + 1;
                arr[r.Next(n)] = rdm_max; // Initial value
                while (i < (n - 1))
                {
                    // Choose a random position
                    rdm_pos = r.Next(n);
                    if (arr[rdm_pos] == 0)
                    {
                        // If unvisited, set a value
                        coefficient = r.NextDouble() * adder + 1;
                        rdm_max -= coefficient;
                        arr[rdm_pos] = rdm_max;
                        i++;
                    }
                }
                return arr;
            }

            /// <summary>
            /// Generates a random array where when the array is sorted difference between each consecutive element is a constant.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <param name="adder"></param>
            /// <returns></returns>
            public static double[] SequentialArray(int n, double max, double adder)
            {
                double[] arr = new double[n];
                double rdm_max, coefficient;
                int rdm_pos, i = 0;
                rdm_max = r.NextDouble() * max;
                coefficient = r.NextDouble() * adder + 1;
                arr[r.Next(n)] = rdm_max;
                while (i < (n - 1))
                {
                    rdm_pos = r.Next(n);
                    if (arr[rdm_pos] == 0)
                    {
                        rdm_max -= coefficient;
                        arr[rdm_pos] = rdm_max;
                        i++;
                    }
                }
                return arr;
            }

            /// <summary>
            /// Generates a random array where when the array is sorted difference between each sorted element is a constant.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public static double[] IncrementialArray(int n, double max)
            {
                double[] arr = new double[n];
                double rdm_max, coefficient;
                int rdm_pos, i = 0;
                rdm_max = r.NextDouble() * max + 1;
                coefficient = 1;
                arr[r.Next(n)] = rdm_max;
                while (i < (n - 1))
                {
                    rdm_pos = r.Next(n);
                    if (arr[rdm_pos] == 0)
                    {
                        rdm_max += coefficient;
                        arr[rdm_pos] = rdm_max;
                        i++;
                    }
                }
                return arr;
            }

            /// <summary>
            /// Generates fibonacci array up to N elements.
            /// <example>
            /// N = 8 , Returns; 1 1 2 3 5 8 13 21
            /// </example>
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
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
                    arr[p++] = num2;
                }
                return arr;
            }

            /// <summary>
            /// Von Neumann Middle Square Method is a method of generating random numbers.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int[] MiddleSquareMethod(int n, int digits)
            {
                int[] nums = new int[n];
                int[] a = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };
                int sqn, next_num, trim, seed;
                for (int n_i = 0; n_i < n; n_i++)
                {
                    seed = r.Next();
                    sqn = seed * seed;
                    next_num = 0;
                    trim = digits / 2;
                    sqn /= a[trim];
                    for (int i = 0; i < digits; i++)
                    {
                        next_num += (sqn % (a[trim])) * (a[i]);
                        sqn /= 10;
                    }
                    nums[n_i] = next_num;
                    seed = next_num;
                }
                return nums;
            }

            /// <summary>
            /// Uses Playing Cards Method to generate random numbers from 0 to 13^3 = 2197. 
            /// Dont use it for big numbers of n because you wont see a high variety of numbers.
            /// 
            /// X Y and Z are basically simulations of picking a random card by dividing 52 card deck into 3 13 card decks
            /// and numbering each card from 1 to 13, and then picking any card from each deck.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static double[] PlayingCardsMethod(int n)
            {
                double[] nums = new double[n];
                double x, y, z, r1;
                for (int i = 0; i < n; i++)
                {
                    x = r.Next(13);
                    y = r.Next(13);
                    z = r.Next(13);
                    r1 = 0;
                    r1 = (r1 + x - 1) / 13;
                    r1 = (r1 + y - 1) / 13;
                    r1 = (r1 + z - 1) / 13;
                    nums[i] = r1;
                }
                return nums;
            }

            /// <summary>
            /// One of the most basic random number generators.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public static double[] LinearCongruentalMethod(int n, double max)
            {
                double[] nums = new double[n];
                double seed = r.NextDouble() % max;
                double c = r.NextDouble() % 1000000;
                double b = r.NextDouble();
                nums[0] = seed;
                for (int i = 1; i < n; i++)
                {
                    nums[i] = (nums[i - 1] * c + b) % max;
                }
                return nums;
            }

            /// <summary>
            /// Slightly bad algorithm, it uses modulo on Fibonacci array to get numbers. 
            /// This algorithm is categorized under "Shift-Register Algorithms", which are basically dependent on series such as
            /// Fibonacci or Lucas.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public static int[] LaggedFibonacciMethod(int n, int max)
            {
                int[] fiboArr = FibonacciArray(n);
                int[] nums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    nums[i] = fiboArr[i] % max;
                }
                return nums;
            }

            /* Skipped algorithms:
             * Algorithm 147 Method
             * Engel Algorithm
             * Blum-Blum-Shub Algorithm
             * Exponential Based Method
             */
        }

        public class Puzzles
        {
            /// <summary>
            /// Longest Increasing Subsequence means a subsequence such that elements are rising and they come one after another in the array (left to right)
            /// This is the Naive Approach.
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int LongestIncreasingSubsequenceNaive(int[] arr, int n)
            {
                int max = 1;
                LongestIncreasingSubsequenceNaiveR(arr, n, ref max);
                return max;
            }
            private static int LongestIncreasingSubsequenceNaiveR(int[] arr, int n, ref int max)
            {
                /* To make use of recursion, the function must return 2 things:
                 * 1 - Length of LIS ending with element ar[n-1]. max_ending_here serves this purpose.
                 * 2 - Overall maximum (max passed by reference) as the LIS may end with an element before arr[n-1].
                 */
                // base case
                if (n == 1) return 1;

                int res;
                int max_ending_here = 1; // length of LIS ending with arr[n-1]

                // Get all LIS endings with arr[0], arr[1], ..., arr[n-2]
                for (int i = 1; i < n; i++)
                {
                    res = LongestIncreasingSubsequenceNaiveR(arr, i, ref max);
                    if (arr[i - 1] < arr[n - 1] && res + 1 > max_ending_here)
                    {
                        max_ending_here = res + 1; // If arr[i-1] is smaller than arr[n-1] and max_ending with arr[n-1] needs update, do it
                    }
                }

                // Compare max_ending_here with total max (passed by reference)
                if (max < max_ending_here)
                {
                    max = max_ending_here;
                }

                return max_ending_here; // return length of LIS ending with arr[n-1]
            }

            /// <summary>
            /// Longest Increasing Subsequence means a subsequence such that elements are rising and they come one after another in the array (left to right)
            /// This is the Dynamic Programming Approach, where certain re-calculcations are avoided thanks to dynamic programming.
            /// 
            /// Time Complexity : O(n^2)
            /// </summary>
            public static int LongestIncreasingSubsequenceDynamic(int[] arr)
            {
                int n = arr.Length;
                int[] lis = new int[n];
                int i, j, max = 0;

                // Initializations
                for (i = 0; i < n; i++)
                {
                    lis[i] = 1;
                }

                // Computations - Bottom Up (a.k.a. Tabular)
                for (i = 1; i < n; i++)
                {
                    for (j = 0; j < i; j++)
                    {
                        if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        {
                            lis[i] = lis[j] + 1;
                        }
                    }
                }

                // Pick maximum
                for (i = 0; i < n; i++)
                {
                    if (max < lis[i])
                    {
                        max = lis[i];
                    }
                }

                return max;
            }
        }
    }
}
