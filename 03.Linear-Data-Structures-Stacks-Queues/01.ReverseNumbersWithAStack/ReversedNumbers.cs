namespace _01.ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedNumbers
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            foreach (var element in input)
            {
                stack.Push(element);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
