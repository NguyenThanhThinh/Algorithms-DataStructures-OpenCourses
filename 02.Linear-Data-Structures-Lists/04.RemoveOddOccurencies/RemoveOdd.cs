namespace _04.RemoveOddOccurencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RemoveOdd
    {
        public static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int item in elements)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 1;
                }
                else
                {
                    dict[item]++;
                }
            }

            foreach (KeyValuePair<int, int> keyValuePair in dict)
            {
                if (keyValuePair.Value % 2 == 0)
                {
                    for (int i = 0; i < keyValuePair.Value; i++)
                    {
                        Console.Write(keyValuePair.Key + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
