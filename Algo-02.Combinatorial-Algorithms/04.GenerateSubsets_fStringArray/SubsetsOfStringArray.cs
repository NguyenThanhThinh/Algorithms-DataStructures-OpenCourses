namespace _04GenerateSubsetsОfStringArray
{
    using System;
    using System.Linq;

    /*Write a recursive program for generating and printing all subsets of k strings from given set of strings s.*/
    
    public class SubsetsOfStringArray
    {
        private static string[] strings;
        private static string[] workArr;

        private static int k;

        public static void Main()
        {
            Console.Write("Insert strings separated by space(s) = ");
            strings = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            Console.Write($"Combinations < {strings.Length} = ");
            k = int.Parse(Console.ReadLine());

            workArr = new string[k];
            GenerateSubSet();
        }

        private static void GenerateSubSet(int index = 0, int position = 0)
        {
            if (index >= workArr.Length)
            {
                PrintSet();
            }
            else
            {
                for (int i = position; i < strings.Length; i++)
                {
                    workArr[index] = strings[i];
                    GenerateSubSet(index+1, i+1);
                }
            }
        }

        private static void PrintSet() => Console.WriteLine("(" + string.Join(", ", workArr) + ")");
    }
}
