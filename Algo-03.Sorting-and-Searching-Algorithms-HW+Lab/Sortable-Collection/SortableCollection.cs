namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static Random random = new Random();

        public SortableCollection()
        {
            this.Items = new List<int>();
        }

        public SortableCollection(IEnumerable<int> items)
        {
            this.Items = new List<int>(items);
        }

        public SortableCollection(params int[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<int> Items { get; } = new List<int>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<int> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item) => this.BinarySearchProcedure(item, 0, this.Count);

        // One test fail
        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex)
            {
                return -1;
            }

            int midPoint = startIndex + (endIndex - startIndex) / 2;

            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midPoint);
            }
            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midPoint + 1, endIndex);
            }

            return midPoint;
        }

        public int InterpolationSearch(int searchValue)
        {
            // Returns index of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = this.Items.Count - 1;
            int mid;

            while (this.Items[low] < searchValue && this.Items[high] >= searchValue)
            {
                mid = low + (searchValue - this.Items[low]) * (high - low) / (this.Items[high] - this.Items[low]);

                if (this.Items[mid] < searchValue)
                    low = mid + 1;
                else if (this.Items[mid] > searchValue)
                    high = mid - 1;
                else
                    return mid;
            }

            if (this.Items[low] == searchValue)
            {
                return low;
            }
            return -1; // Not found
        }

        public void Shuffle()
        {
            int n = this.Items.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                int temp = this.Items[r];
                this.Items[r] = this.Items[i];
                this.Items[i] = temp;
            }
        }

        public int[] ToArray() => this.Items.ToArray();

        public override string ToString() => $"[{string.Join(", ", this.Items)}]";
    }
}