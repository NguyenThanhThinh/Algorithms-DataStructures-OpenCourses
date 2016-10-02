using System;
using System.Collections.Generic;
using System.Linq;

namespace Cables
{
    class Cables
    {
        static List<int> input;
        static void Main()
        {
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int connectorsCost = int.Parse(Console.ReadLine()) * 2;
            input.Insert(0, 0);

            for (int mainIndex = input.Count - 1; mainIndex > 0; mainIndex--)
            {
                var getRangetoArray = Enumerable.Range(1, mainIndex - 1).ToArray();
                var sums = GenerateSums(getRangetoArray, mainIndex);
                for (int index = 0; index < sums.Length; index++)
                {
                    var s = sums[index];
                    int currSum = 0;
                    for (int j = 0; j < s.Length; j++)
                    {
                        var item = s[j];
                        currSum += input[item];
                    }
                    currSum -= (s.Length - 1) * connectorsCost;
                    if (currSum > input[mainIndex])
                    {
                        input[mainIndex] = currSum;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", input.Skip(1)));
        }

        //StackOF generate all sums
        static int[][] GenerateSums(int[] array, int k)
        {
            int[][][] ways = new int[k + 1][][];
            ways[0] = new[] { new int[0] };

            for (int i = 1; i <= k; i++)
            {
                ways[i] = (
                    from valie in array
                    where i - valie >= 0
                    from subway in ways[i - valie]
                    where subway.Length == 0 || subway[0] >= valie
                    select Enumerable.Repeat(valie, 1)
                        .Concat(subway)
                        .ToArray()
                ).ToArray();
            }

            return ways[k];
        }
    }
}
