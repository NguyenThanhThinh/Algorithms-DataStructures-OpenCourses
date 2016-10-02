namespace Sortable_Collection
{
    using System;

    using Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new InsertionSorter<int>());
            Console.WriteLine(collectionToSort);
            Console.WriteLine();
            collectionToSort.Shuffle();
            Console.WriteLine(collectionToSort);

        }
    }
}
