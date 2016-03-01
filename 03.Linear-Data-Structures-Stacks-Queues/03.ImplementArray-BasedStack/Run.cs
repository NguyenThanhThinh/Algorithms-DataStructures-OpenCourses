namespace _03.ImplementArray_BasedStack
{
    using System;

    public class Run
    {
        public static void Main(string[] args)
        {
            var abStack = new ArrayStack<int>();

            abStack.Push(2);
            abStack.Push(20);
            abStack.Push(5);
            abStack.Push(16);
            abStack.Push(16);
            abStack.Push(16);
            abStack.Push(16);
            abStack.Push(16);
            abStack.Push(16);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);
            abStack.Push(12);

            var array = abStack.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

        }
    }
}
