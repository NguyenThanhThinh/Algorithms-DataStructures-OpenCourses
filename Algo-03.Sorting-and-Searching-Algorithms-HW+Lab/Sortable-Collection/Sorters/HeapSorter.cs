namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.HeapSort(collection);
        }

        public void HeapSort(List<T> arr)
        {
            for (int i = (arr.Count / 2) - 1; i >= 0; i--)
            {
                ShiftDown(arr, i, arr.Count);
            }

            for (int i = arr.Count - 1; i >= 1; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                ShiftDown(arr, 0, i - 1);
            }
        }

        private void ShiftDown(List<T> arr, int root, int bottom)
        {
            bool done = false;
            int maxChild = 0;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                {
                    maxChild = root * 2;
                }
                else if (arr[root * 2].CompareTo(arr[root * 2 + 1]) > 0)
                {
                    maxChild = root * 2;
                }
                else
                {
                    maxChild = root * 2 + 1;
                }

                if (arr[root].CompareTo(arr[maxChild]) < 0)
                {
                    T temp = arr[root];
                    arr[root] = arr[maxChild];
                    arr[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}
