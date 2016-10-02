namespace _07.LinkedQueue
{
    using System;

    public class Run
    {
        public static void Main(string[] args)
        {
            var linkeQueue = new LinkedQueue<int>();
            linkeQueue.Enqueue(1);
            linkeQueue.Enqueue(3);
            linkeQueue.Enqueue(100);
            Console.WriteLine(linkeQueue.Count);
            linkeQueue.Dequeue();
            linkeQueue.Dequeue();
            linkeQueue.Dequeue();
            Console.WriteLine(linkeQueue.Count);

            try
            {
                linkeQueue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            linkeQueue.Enqueue(1);
            linkeQueue.Enqueue(3);

            while (linkeQueue.Count > 0)
            {
                Console.WriteLine(linkeQueue.Dequeue());
            }

            linkeQueue.Enqueue(1);
            linkeQueue.Enqueue(3);

            var arr = linkeQueue.ToArray();
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
