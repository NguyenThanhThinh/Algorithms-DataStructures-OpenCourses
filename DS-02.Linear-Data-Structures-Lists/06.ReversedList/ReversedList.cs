namespace _06.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IReversedList<T>, IEnumerable<T>
    {
        private const int ListInitialCapacity = 16;

        private T[] internalStorage;

        private int capacity;

        public ReversedList(int capacity = ListInitialCapacity)
        {
            this.Capacity = capacity;
            this.internalStorage = new T[this.Capacity];
            this.Size = 0;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    value = ListInitialCapacity;
                }

                this.capacity = value;
            }
        }

        public int Size { get; private set; }

        public void Add(T item)
        {
            if (this.Size >= this.Capacity)
            {
                this.IncreaseCapacity();
            }

            this.internalStorage[this.Size] = item;
            this.Size++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int reversedIndex = this.Size - index - 1;
            for (var i = reversedIndex; i < this.internalStorage.Length -1; i++)
            {
                this.internalStorage[i] = this.internalStorage[i+1];
            }
            this.Size--;
        }

        public void Clear()
        {
            for (var i = 0; i < this.Size; i++)
            {
                this.internalStorage[i] = default(T);
            }

            this.Size = 0;
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < this.Size; i++)
            {
                if (this.internalStorage[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.internalStorage[this.Size - 1 - index];
            }

            set
            {
                this.ValidateIndex(index);
                this.internalStorage[this.Size - 1 - index] = value;
            }
        }

        public override string ToString()
        {
            return
                this.Size == 0
                ? $"Empty GenericList<{typeof(T)}>"
                : $"[{string.Join(", ", this.internalStorage.Take(this.Size))}]";
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.Size - 1; i >= 0; i--)
            {
                yield return this.internalStorage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IncreaseCapacity()
        {
            this.capacity = this.internalStorage.Length * 2;
            var newInternalStorage = new T[this.capacity];
            for (var i = 0; i < this.internalStorage.Length; i++)
            {
                newInternalStorage[i] = this.internalStorage[i];
            }

            this.internalStorage = newInternalStorage;
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Size || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}