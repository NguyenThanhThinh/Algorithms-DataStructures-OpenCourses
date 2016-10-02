namespace _01.GenerateVariationsWithRepetition
{
    using System;

    public class VariationsWithRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            GenerateVariations(array, n);
        }

        private static void GenerateVariations(int[] arr, int sizeOfSet, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateVariations(arr, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] arr) => Console.WriteLine($"({string.Join(", ", arr)})");
    }
}