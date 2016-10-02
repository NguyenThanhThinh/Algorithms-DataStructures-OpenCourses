namespace _04.CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];

            GenerateCombinations(arr, n, 0);
        }

        private static void GenerateCombinations(int[] arr, int sizeOfSet, int index, int element = 1)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = element; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, sizeOfSet, index + 1, i+1);
                }
            }
        }

        private static void Print(int[] arr) => Console.WriteLine($"({string.Join(", ", arr)})");
    }
}
