using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Guitars
{
    public class Item
    {
        public int Weight { get; set; }
        public int Price { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int[] itemsInput = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int start = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            var items = new List<Item>();

            foreach (var item in itemsInput)
            {
                items.Add(new Item()
                {
                    Weight = item,
                    Price = 1
                });
            }
//            new Item { Weight = 63, Price = 1},
//            new Item { Weight = 140, Price = 1},
//            new Item { Weight = 99, Price = 1},
//            new Item { Weight = 96, Price = 1},
//            new Item { Weight = 154, Price = 1},
//            new Item { Weight = 18, Price = 1},
//            new Item { Weight = 137, Price = 1},
//            new Item { Weight = 162, Price = 1},
//            new Item { Weight = 14, Price = 1},
//            new Item { Weight = 88, Price = 1},
            //15, 2, 9, 10
            //74, 39, 127, 95, 63, 140, 99, 96, 154, 18, 137, 162, 14, 88
            var knapsackCapacity = max-start;

            var itemsTaken = FillKnapsack(items.ToArray(), knapsackCapacity);
            
            if (itemsTaken.Sum(i => i.Weight)+start > max)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine("{0}", itemsTaken.Sum(i => i.Weight) + start);
            }
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];

            // Calculate maxPrice[0, 0...capacity]
            for (int c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    isItemTaken[0, c] = true;
                }
            }

            // Calculate maxPrice[1...len(items), 0...capacity]
            for (int i = 1; i < items.Length; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    // Don't take item i
                    maxPrice[i, c] = maxPrice[i - 1, c];

                    // Try to take item i (if it gives better price)
                    var remainingCapacity = c - items[i].Weight;
                    if (remainingCapacity >= 0 &&
                        maxPrice[i - 1, remainingCapacity] + items[i].Price > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, remainingCapacity] + items[i].Price;
                        isItemTaken[i, c] = true;
                    }
                }


            }

            // Print the takenItems
            var itemsTaken = new List<Item>();
            int itemIndex = items.Length - 1;
            while (itemIndex >= 0)
            {
                if (isItemTaken[itemIndex, capacity])
                {
                    itemsTaken.Add(items[itemIndex]);
                    capacity -= items[itemIndex].Weight;
                }
                itemIndex--;
            }
            itemsTaken.Reverse();

            return itemsTaken.ToArray();
        }
    }
}
