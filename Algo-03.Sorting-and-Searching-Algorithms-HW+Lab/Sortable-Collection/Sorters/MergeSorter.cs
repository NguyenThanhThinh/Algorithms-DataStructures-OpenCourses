namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class MergeSorter : ISorter<int>
    {
        public void Sort(List<int> collection)
        {
            this.MergeSort(collection, 0, collection.Count);
        }

        public void MergeSort(List<int> array, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                this.MergeSort(array, start, middle);
                this.MergeSort(array, middle + 1, end);
                this.Merge(array, start, middle, middle + 1, end);
            }
        }

        public void Merge(List<int> array, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (array[left] <= array[middle1])
                {
                    temp[i++] = array[left++];
                }
                else
                {
                    temp[i++] = array[middle1++];
                }
            }
            if (left > middle)
            {
                for (int j = middle1; j <= right; j++)
                {
                    temp[i++] = array[middle1++];
                }
            }
            else
            {
                for (int j = left; j <= middle; j++)
                {
                    temp[i++] = array[left++];
                }
            }

            Array.Copy(temp, 0, array.ToArray(), oldPosition, size);
        }
    }
}
