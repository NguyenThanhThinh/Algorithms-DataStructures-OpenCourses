using System;
using System.Linq;

namespace _04.RepresentingSumWithUnlimitedAmountCoins
{
    public class SumsWithUnlimitedAmountCoins
    {
        private static int totalCount;

        public static void Main()
        {
            var targetSum = int.Parse(Console.ReadLine());
            var coins = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            GeneratCombinations(targetSum, coins);

            Console.WriteLine(totalCount);
        }

        private static void GeneratCombinations(int targetSum, int[] coins)
        {
            var rows = coins.Length + 1;
            var cols = targetSum + 1;
            int[,] storage = new int[rows, cols];

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (coins[row - 1] == col)
                    {
                        storage[row, col] = storage[row - 1, col] + 1;
                    }
                    else
                    {
                        if (coins[row - 1] < col)
                        {
                            storage[row, col] = storage[row - 1, col] + storage[row, col - coins[row - 1]];
                        }
                        else
                        {
                            storage[row, col] = storage[row - 1, col];
                        }
                    }
                }
            }

            totalCount = storage[coins.Length, targetSum];
        }
    }
}
