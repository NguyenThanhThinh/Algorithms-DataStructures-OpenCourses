namespace _01.PermutationsRecursively
{
    using System;
    using System.Linq;

    /*Write a recursive program for generating and printing all permutations (without repetition) of the numbers 1, 2, ..., n for a given integer number n (n > 0). The number of permutations is found by calculating n!*/


    public class PermutationsRecursively
    {
        private static int countOfPermutations;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();

            Permute(array);

            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void Permute(int[] arr, int startIndex = 0)
        {
            if (startIndex>= arr.Length-1)
            {
                Console.WriteLine(string.Join(", ", arr));
                countOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i < arr.Length; i++)
                {
                    Swap(ref arr[startIndex], ref arr[i]);
                    Permute(arr, startIndex+1);
                    Swap(ref arr[i], ref arr[startIndex]);
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i==j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
