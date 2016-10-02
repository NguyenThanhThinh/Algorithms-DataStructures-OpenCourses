namespace Sortable_Collection.Sorters
{
    using System.Collections.Generic;

    using Contracts;

    public class BucketSorter : ISorter<int>
    {
        public double Max { get; set; }

        public void Sort(List<int> collection)
        {
            var buckets = new List<int>[collection.Count];

            foreach (var element in collection)
            {
                int bucketIndex = (int)(element / this.Max * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            var sorter = new Quicksorter<int>();

            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    sorter.Sort(bucket);
                }
            }

            int index = 0;
            foreach (List<int> bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (var item in bucket)
                {
                    collection[index] = item;
                    index++;
                }
            }
        }
    }
}
