namespace _01.RecursiveArraySum
{
    using System;

    public class RecursiveArraySum
    {
        public static void Main()
        {
            // Test array
            var array = new[] { 2, 4, 123, 23, 2 };
            Console.WriteLine(FindSum(array, 0));
        }

        public static int FindSum(int[] arr, int currentIndex)
        {
            if (currentIndex == arr.Length)
            {
                return 0;
            }

            return arr[currentIndex] + FindSum(arr, currentIndex + 1);
        }
    }
}
