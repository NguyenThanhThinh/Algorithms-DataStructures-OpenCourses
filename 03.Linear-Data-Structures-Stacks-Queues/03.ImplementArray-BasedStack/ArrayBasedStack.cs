namespace _03.ImplementArray_BasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count<=0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            this.Count--;
            var element = this.elements[this.Count];
            this.elements[this.Count] = default(T);
            return element;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            this.CopyAllElementsTo(resultArr);
            return resultArr;
        }

        private void Grow()
        {
            T[] newArr = new T[2 * this.elements.Length];
            this.CopyAllElementsTo(newArr);
            this.elements = newArr;
        }

        private void CopyAllElementsTo(T[] resultArr) => Array.Copy(this.elements, resultArr, this.Count);
    }

}