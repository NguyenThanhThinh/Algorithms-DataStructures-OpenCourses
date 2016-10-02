namespace _05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private LinkedStackNode<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            var newNode = new LinkedStackNode<T>(element)
            {
                NextNode = this.firstNode
            };
            this.firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var currentNode = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return currentNode.Value;
        }

        public T Peek()
        {
            var currentNode = this.firstNode;

            return currentNode.Value;
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            var currNode = this.firstNode;
            var arrIndex = 0;
            while (currNode != null)
            {
                arr[arrIndex] = currNode.Value;
                arrIndex++;
                currNode = currNode.NextNode;
            }

            return arr;
        }
    }
}