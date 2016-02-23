using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAndAverage
{
    public class SumAverage
    {
        public static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine($"Sum={elements.Sum()}; Average={elements.Average()}");
        }
    }
}
