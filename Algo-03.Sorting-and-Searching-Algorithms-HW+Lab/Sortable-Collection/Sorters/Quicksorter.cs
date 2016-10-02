namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = array[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    this.Swap(array, i, storeIndex);

                    storeIndex++;
                }
            }

            storeIndex--;

            this.Swap(array, start, storeIndex);

            this.QuickSort(array, start, storeIndex);
            this.QuickSort(array, storeIndex + 1, end);
        }

        private void Swap(List<T> array, int x, int y)
        {
            T temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }
    }
}
