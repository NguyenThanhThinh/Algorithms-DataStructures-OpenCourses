namespace _03.CombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    /*Write an iterative program to generate all combinations (without repetition) of k elements from a set of n elements. Remember, in combinations, the order of elements doesn’t matter – (1 2) and (2 1) are considered the same combination. You are not allowed to use recursion. Search the Internet for a suitable algorithm.*/

    public class CombinationsIteratively
    {
        public static void Main()
        {
            int countOfCombinations = 0;
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            foreach (var combination in Combinations(k, n))
            {
                countOfCombinations++;
                Console.WriteLine(string.Join(", ", combination));
            }
            Console.WriteLine($"Total combinations: {countOfCombinations}");
        }

        private static IEnumerable<int[]> Combinations(int k, int n)
        {
            var result = new int[k];
            var stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }

        }
    }
}
