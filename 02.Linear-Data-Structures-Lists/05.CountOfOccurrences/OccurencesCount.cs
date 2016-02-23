namespace _05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OccurencesCount
    {
        public static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).Where(e => e >= 0 && e <= 1000).ToList();
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

            foreach (var item in dict.OrderBy(i => i.Key))
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }
        }
    }
}
