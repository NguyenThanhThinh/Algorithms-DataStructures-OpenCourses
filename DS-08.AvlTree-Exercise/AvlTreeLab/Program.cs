namespace AvlTreeLab
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new AvlTree<int>();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(1);
            }

            Console.WriteLine();
        }
    }
}
