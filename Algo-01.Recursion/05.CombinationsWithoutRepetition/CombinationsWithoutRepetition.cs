namespace _05.CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int startValue = 1;
            int startIndex = 0;
            int[] arr = new int[k];
            GenCombs(arr, startIndex, startValue, n);
        }

        public static void GenCombs(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("(" + string.Join(", ", arr) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenCombs(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}
