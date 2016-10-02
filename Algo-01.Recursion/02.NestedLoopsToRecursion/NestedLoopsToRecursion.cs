namespace _02.NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
      	private static int[] array;
      	private static int numberOfLoops;
        public static void Main()
        {
            Console.Write("Enter number of iterations: ");
            numberOfLoops = int.Parse(Console.ReadLine());
			array = new int[numberOfLoops];
            NestedLoops(0);
        }

        public static void NestedLoops(int index)
        {
            if (index == numberOfLoops)
            {
                // A combination was found --> print it
                Console.WriteLine(string.Join(" ", array));
              	return;
            }
            for (int i = 1; i <= numberOfLoops; i++)
            {
              	array[index] = i;
                NestedLoops(index+1);
            }
        }
    }
}
