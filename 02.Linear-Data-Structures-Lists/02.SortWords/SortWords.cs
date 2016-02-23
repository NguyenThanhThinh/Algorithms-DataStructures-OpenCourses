namespace _02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();
            elements.Sort();
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
