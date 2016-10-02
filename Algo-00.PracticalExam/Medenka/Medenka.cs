using System;
using System.Linq;
using System.Text;

namespace Medenka
{
    class Medenka
    {
        static StringBuilder result = new StringBuilder();
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string output = string.Empty;
            SplitMedenka(input, 0, output);
            Console.Write(result);
        }

        private static void SplitMedenka(int[] arr, int index, string output)
        {
            int sum = 0;

            if (index == arr.Length)
            {
                result.AppendLine(output.Remove(output.Length-1));
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (sum > 1)
                {
                    return;
                }
                output += arr[i];
                sum += arr[i];
                if (sum ==1)
                {
                    SplitMedenka(arr, i+1, output+"|");
                }
            }
        }
    }
}
