namespace _02.QueueSequence
{
    using System;
    using System.Collections.Generic;

    public class QueueSequence
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();
            int n = int.Parse(Console.ReadLine());
            var output = new List<int>();
            queue.Enqueue(n);
            int neededResults = 50;

            while (neededResults > 0)
            {
                var currentNum = queue.Dequeue();
                output.Add(currentNum);
                neededResults--;

                queue.Enqueue(currentNum + 1);
                queue.Enqueue((currentNum * 2) + 1);
                queue.Enqueue(currentNum + 2);
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
