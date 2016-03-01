namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> start;

        private QueueNode<T> end;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.start = this.end = new QueueNode<T>(element);
            }
            else
            {
                var newTail = new QueueNode<T>(element);
                newTail.PrevNode = this.end;
                this.end.NextNode = newTail;
                this.end = newTail;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var firstElement = this.start;
            this.start = this.start.NextNode;
            if (this.start != null)
            {
                this.start.PrevNode = null;
            }
            else
            {
                this.end = null;
            }

            this.Count--;
            return firstElement.Value;
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            int index = 0;
            var currentNode = this.start;
            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return arr;
        }
    }
}