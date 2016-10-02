using System.Linq;

namespace _01.ReverseArray
{
    using System;

    public class ReverseArray
    {
        public static void Main()
        {
          	var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var reversedArr = new int[arr.Length];
            var output = ReverseArr(arr, reversedArr, arr.Length - 1, 0);

            Console.WriteLine(string.Join(" ", output));
        }

        public static int[] ReverseArr(int[] arr, int[] reversed, int end, int start)
        {
            if (end == 0 && start == arr.Length - 1)
            {
                reversed[start] = arr[end];
                return reversed;
            }

            reversed[start] = arr[end];
            return ReverseArr(arr, reversed, end - 1, start + 1);
        }
    }
}
