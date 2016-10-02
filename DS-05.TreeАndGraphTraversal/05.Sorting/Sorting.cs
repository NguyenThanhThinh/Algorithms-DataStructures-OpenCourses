namespace _05.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Sorting
    {
        private static readonly HashSet<string> Permutations = new HashSet<string>();
        private static int consecutiveElements;
        private static int numbersCunt;

        public static void Main()
        {
            var sequence = ReadInput();

            var queue = new Queue<Permutation<int>>();
            var current = new Permutation<int>(sequence);
            queue.Enqueue(current);

            var numberOfReverses = BreathFirstSearch(queue);

            Console.WriteLine(numberOfReverses);
        }

        private static int[] ReadInput()
        {
            numbersCunt = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            consecutiveElements = int.Parse(Console.ReadLine());
            return sequence;
        }

        private static int BreathFirstSearch(Queue<Permutation<int>> queue)
        {
            while (queue.Count > 0)
            {
                var currentPerm = queue.Dequeue();

                if (currentPerm.IsSorted())
                {
                    return currentPerm.Order;
                }

                for (int i = 0; i <= currentPerm.Sequence.Length - consecutiveElements; i++)
                {
                    int[] currentSequence = new int[numbersCunt];
                    Array.Copy(currentPerm.Sequence, currentSequence, currentPerm.Sequence.Length);

                    var reversed = currentSequence.Skip(i).Take(consecutiveElements).Reverse().ToList();
                    for (int j = i, index = 0; j < i + consecutiveElements; j++, index++)
                    {
                        currentSequence[j] = reversed[index];
                    }

                    var nextPermutation = new Permutation<int>(currentSequence, currentPerm.Order + 1);
                    if (!Permutations.Contains(nextPermutation.ToString()))
                    {
                        Permutations.Add(nextPermutation.ToString());
                        queue.Enqueue(nextPermutation);
                    }
                }
            }

            return -1;
        }
    }
}
