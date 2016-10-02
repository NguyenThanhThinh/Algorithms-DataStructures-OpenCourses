namespace _02.PermutationsIteratively
{
    using System;
    using System.Linq;

    /*The above problem presented a recursive solution for generating all permutations (without repeating elements) of a collection. Your task is to write a non-recursive algorithm to achieve the same goal. There shouldn’t be any recursive calls in your program (only loops). You may use the examples for problem 1 to check whether your solution is correct.*/

    public class PermutationsIteratively
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var numberOfPerm = 1;
            var elements = Enumerable.Range(1, num).ToArray();
            var workArr = Enumerable.Range(0, elements.Length + 1).ToArray();

            PrintPerm(elements);

            var index = 1;

            while (index < elements.Length)
            {
                workArr[index]--;
                var j = 0;
                if (index % 2 == 1)
                {
                    j = workArr[index];
                }

                SwapInts(ref elements[j], ref elements[index]);
                index = 1;
                while (workArr[index] == 0)
                {
                    workArr[index] = index;
                    index++;
                }
                numberOfPerm++;
                PrintPerm(elements);
            }
            Console.WriteLine($"Total permutations: {numberOfPerm}");
        }

        private static void PrintPerm(int[] elements) => Console.WriteLine(string.Join(", ", elements));

        private static void SwapInts(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
