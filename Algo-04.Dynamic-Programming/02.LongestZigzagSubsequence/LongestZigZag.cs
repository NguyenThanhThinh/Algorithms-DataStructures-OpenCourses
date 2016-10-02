using System;
using System.Collections.Generic;

namespace _02.LongestZigzagSubsequence
{
    public class LongestZigZag
    {
        private static int[] length;
        private static int[] previous;

        public static void Main()
        {
            var sequence = new[] { 1, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };

            var longestSeq = FindZigZag(sequence);

            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindZigZag(int[] sequence)
        {
            length = new int[sequence.Length];
            previous = new int[sequence.Length];

            var maxLen = 0;
            var lastIndex = -1;

            for (int x = 0; x < sequence.Length; x++)
            {
                length[x] = 1;
                previous[x] = -1;

                for (int i = 0; i < x; i++)
                {
                    if (sequence[i] < sequence[x] &&
                        length[i] + 1 > length[x])
                    {
                        length[x] = length[i] + 1;
                        previous[x] = i;
                    }
                }

                if (length[x] > maxLen)
                {
                    maxLen = length[x];
                    lastIndex = x;
                }
            }

            var longestZigZagSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestZigZagSeq.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestZigZagSeq.Reverse();

            return longestZigZagSeq.ToArray();
        }
    }
}
