namespace _04.TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoi
    {
        private static int stepsTaken = 0;

        private static Stack<int> source;

        private static readonly Stack<int> destination = new Stack<int>();

        private static readonly Stack<int> spare = new Stack<int>();

        public static void Main()
        {
         	Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, n).Reverse();
            source = new Stack<int>(range);

            PrintPegs();
            MoveDisks(n, source, spare, destination);
        }

        private static void PrintPegs()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(",", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisk}");
                PrintPegs();
                return;
            }

            MoveDisks(bottomDisk - 1, source, destination, spare);
            destination.Push(source.Pop());
            stepsTaken++;
            Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisk}");
            PrintPegs();
            MoveDisks(bottomDisk - 1, spare, source, destination);
        }
    }
}
