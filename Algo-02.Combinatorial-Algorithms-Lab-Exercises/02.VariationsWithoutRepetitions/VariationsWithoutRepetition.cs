using System;

namespace _02.VariationsWithoutRepetitions
{
    public class VariationsWithoutRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            bool[] used = new bool[n+1];

            GenerateVariations(array, n, used);
        }

        private static void GenerateVariations(int[] arr, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
                return;
            }
            for (int i = 1; i <= sizeOfSet; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[index] = i;
                    GenerateVariations(arr, sizeOfSet, used, index + 1);
                    used[i] = false;
                }
            }
        }

        private static void Print(int[] arr) => Console.WriteLine($"({string.Join(", ", arr)})");
    }
}
