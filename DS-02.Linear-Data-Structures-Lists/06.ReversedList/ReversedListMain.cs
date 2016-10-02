namespace _06.ReversedList
{
    using System;

    public class ReversedListMain
    {
        public static void Main(string[] args)
        {
            ReversedList<int> ints = new ReversedList<int>();
            ints.Add(23);
            ints.Add(1);
            ints.Add(42);
            ints.Add(87);
            Console.WriteLine(string.Join(", ", ints));

        }
    }
}
