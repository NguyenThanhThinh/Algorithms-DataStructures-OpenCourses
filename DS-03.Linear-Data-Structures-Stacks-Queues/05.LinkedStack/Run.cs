namespace _05.LinkedStack
{
    using System;

    public class Run
    {
        public static void Main(string[] args)
        {
            var linkedStack = new LinkedStack<int>();

            linkedStack.Push(20);
            linkedStack.Push(2);
            linkedStack.Push(12);
            linkedStack.Push(5);
            var arr = linkedStack.ToArray();
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(linkedStack.Peek());
            linkedStack.Pop();
            var arr3 = linkedStack.ToArray();
            Console.WriteLine(string.Join(", ", arr3));
        }
    }
}
